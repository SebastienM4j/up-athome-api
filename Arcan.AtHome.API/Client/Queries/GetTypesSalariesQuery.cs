using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetTypesSalariesQueryResult
    {
        public decimal Id { get; set; }
        public string Libelle { get; set; }
        public bool Tournee { get; set; }
        public bool Releve { get; set; }
        public decimal? TypeIntervenantId { get; set; }
        public string LibelleReference { get; set; }
        public string CodeDMP { get; set; }
        public string Color { get; set; }
    }

    public class GetTypesSalariesQuery : IQuery<GetTypesSalariesQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetTypesSalariesQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetTypesSalariesQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetTypeSalarieQuery", AtHomeUrl)).Result;
            GetTypesSalariesQueryResult[] result = JsonConvert.DeserializeObject<GetTypesSalariesQueryResult[]>(taskResult);

            return result;
        }
    }
}
