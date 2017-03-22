using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
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

    public class GetVillesParCodePostalQuery : IQuery<GetVillesParCodePostalQueryArg, GetVillesParCodePostalQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetVillesParCodePostalQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetVillesParCodePostalQueryResult[] Query(GetVillesParCodePostalQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
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
