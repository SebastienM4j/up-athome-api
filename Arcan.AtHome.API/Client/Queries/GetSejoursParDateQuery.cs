using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Arcan.AtHome.API.Queries
{
    public class GetSejoursParDateQueryArg
    {
        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }
    }

    public class GetSejoursParDateQueryResult
    {
        public decimal SejourId { get; set; }
        public string IdentifiantExterne { get; set; }
        public decimal PatientId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateDebutPrevisionnel { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateFinPrevisionnelle { get; set; }
        public decimal? AntenneId { get; set; }
        public string AntenneNom { get; set; }
        public decimal? UniteServiceId { get; set; }
        public string UniteServiceNom { get; set; }
    }

    public class GetSejoursParDateQuery : IQuery<GetSejoursParDateQueryArg, GetSejoursParDateQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetSejoursParDateQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetSejoursParDateQueryResult[] Query(GetSejoursParDateQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/Sejour/queries/GetSejoursParDateQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetSejoursParDateQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetSejoursParDateQueryResult[]>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
