using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Arcan.AtHome.API.Queries
{
    public class GetPlansSoinsParIdQueryArg
    {
        [Required]
        public decimal PlanSoinsId { get; set; }
    }

    public class GetPlansSoinsParIdQueryResult
    {
        public decimal PlanSoinsId { get; set; }
        public decimal SejourId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateFinPrevisonnelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
        public string TypeIntervenantLibelle { get; set; }
        public LignePlanSoins[] Lignes { get; set; }
        public string Commentaire { get; set; }
    }

    public class GetPlansSoinsParIdQuery : IQuery<GetPlansSoinsParIdQueryArg, GetPlansSoinsParIdQueryResult>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetPlansSoinsParIdQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetPlansSoinsParIdQueryResult Query(GetPlansSoinsParIdQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParIdQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetPlansSoinsParIdQueryResult> result = JsonConvert.DeserializeObject<ActionResult<GetPlansSoinsParIdQueryResult>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
