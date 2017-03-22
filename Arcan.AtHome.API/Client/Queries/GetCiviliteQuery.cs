using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetCiviliteQueryResult
    {
        public decimal Id { get; set; }
        public string Libelle { get; set; }
        public string LibelleLong { get; set; }
    }

    public class GetCiviliteQuery : IQuery<GetCiviliteQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetCiviliteQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetCiviliteQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetCiviliteQuery", AtHomeUrl)).Result;
            GetCiviliteQueryResult[] result = JsonConvert.DeserializeObject<GetCiviliteQueryResult[]>(taskResult);

            return result;
        }
    }
}
