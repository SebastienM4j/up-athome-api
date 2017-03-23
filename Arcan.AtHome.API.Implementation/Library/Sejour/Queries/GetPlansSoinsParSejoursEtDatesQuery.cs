using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetPlansSoinsParSejoursEtDatesQueryArg
    {
        public decimal[] SejourIds { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    }

    public class GetPlansSoinsParSejoursEtDatesQueryResult
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

    public class LignePlanSoins
    {
        public decimal LignePlanSoinsId { get; set; }
        public DayOfWeek Jour { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public bool Obligatoire { get; set; }
        public Acte[] Actes { get; set; }
    }

    public class Acte
    {
        public int ActeId { get; set; }
        public string Libelle { get; set; }
    }

    public class GetPlansSoinsParSejoursEtDatesQuery : AtHomeQuery<GetPlansSoinsParSejoursEtDatesQueryArg, GetPlansSoinsParSejoursEtDatesQueryResult[]>
    {
        public GetPlansSoinsParSejoursEtDatesQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetPlansSoinsParSejoursEtDatesQueryResult[] Query(GetPlansSoinsParSejoursEtDatesQueryArg arg)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParSejoursEtDatesQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetPlansSoinsParSejoursEtDatesQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetPlansSoinsParSejoursEtDatesQueryResult[]>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
