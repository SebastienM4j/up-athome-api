using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetVillesParCodePostalQueryArg
    {
        public string CodePostal { get; set; }
    }

    public class GetVillesParCodePostalQueryResult
    {
        public decimal Id { get; set; }
        public string CodePostal { get; set; }
        public string JourLivraison { get; set; }
        public string Nom { get; set; }
        public decimal? ZSPID { get; set; }
    }

    public class GetVillesParCodePostalQuery : AtHomeQuery<GetVillesParCodePostalQueryArg, GetVillesParCodePostalQueryResult[]>
    {
        public GetVillesParCodePostalQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetVillesParCodePostalQueryResult[] Query(GetVillesParCodePostalQueryArg arg)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Administration/Ville/queries/GetVilleParCodePostalQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            GetVillesParCodePostalQueryResult[] result = JsonConvert.DeserializeObject<GetVillesParCodePostalQueryResult[]>(responseBody);

            return result;
        }
    }
}
