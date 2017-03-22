using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetFonctionQueryResult
    {
        public decimal Id { get; set; }
        public string Libelle { get; set; }
    }

    public class GetFonctionQuery : IQuery<GetFonctionQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetFonctionQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetFonctionQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetFonctionQuery", AtHomeUrl)).Result;
            GetFonctionQueryResult[] result = JsonConvert.DeserializeObject<GetFonctionQueryResult[]>(taskResult);

            return result;
        }
    }
}
