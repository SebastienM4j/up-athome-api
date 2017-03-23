using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetSejoursParIdExterneQueryArg
    {
        public string IdentifiantExterne { get; set; }
    }

    public class GetSejoursParIdExterneQueryResult
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

    public class GetSejoursParIdExterneQuery : AtHomeQuery<GetSejoursParIdExterneQueryArg, GetSejoursParIdExterneQueryResult>
    {
        public GetSejoursParIdExterneQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetSejoursParIdExterneQueryResult Query(GetSejoursParIdExterneQueryArg arg)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/Sejour/queries/GetSejourParIdExterneQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetSejoursParIdExterneQueryResult> result = JsonConvert.DeserializeObject<ActionResult<GetSejoursParIdExterneQueryResult>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
