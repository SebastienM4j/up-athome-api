using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetAntenneQueryResult
    {
        public decimal AntenneId { get; set; }
        public string RaisonSociale { get; set; }
    }

    public class GetAntenneQuery : IQuery<GetAntenneQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetAntenneQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetAntenneQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Etablissement/Antenne/queries/GetAntenneQuery", AtHomeUrl)).Result;
            GetAntenneQueryResult[] result = JsonConvert.DeserializeObject<GetAntenneQueryResult[]>(taskResult);

            return result;
        }
    }
}
