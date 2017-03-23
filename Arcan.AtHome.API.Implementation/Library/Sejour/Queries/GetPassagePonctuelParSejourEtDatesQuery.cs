using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetPassagePonctuelParSejourEtDatesQueryArg
    {
        public decimal SejourId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

    }

    public class GetPassagePonctuelParSejourEtDatesQueryResult
    {
        public decimal Id { get; set; }
        public decimal SejourId { get; set; }
        public decimal TypeIntervenantId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public bool Obligatoire { get; set; }
        public string Commentaire { get; set; }
        public int[] ActeIds { get; set; }
    }

    public class GetPassagePonctuelParSejourEtDatesQuery : AtHomeQuery<GetPassagePonctuelParSejourEtDatesQueryArg, GetPassagePonctuelParSejourEtDatesQueryResult[]>
    {
        public GetPassagePonctuelParSejourEtDatesQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetPassagePonctuelParSejourEtDatesQueryResult[] Query(GetPassagePonctuelParSejourEtDatesQueryArg arg)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/PassagePonctuel/queries/GetPassagePonctuelParSejourEtDatesQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            GetPassagePonctuelParSejourEtDatesQueryResult[] result = JsonConvert.DeserializeObject<GetPassagePonctuelParSejourEtDatesQueryResult[]>(responseBody);

            return result;
        }
    }
}
