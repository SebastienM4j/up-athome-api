using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetActesQueryResult
    {
        public int ActeId { get; set; }
        public string Libelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
    }

    public class GetActesQuery : IQuery<GetActesQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetActesQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetActesQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Sejour/Sejour/queries/GetActesQuery", AtHomeUrl)).Result;
            ActionResult<GetActesQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetActesQueryResult[]>>(taskResult);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
