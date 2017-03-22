using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetTypesIntervenantsQueryResult
    {
        public decimal TypeIntervenantId { get; set; }
        public string Libelle { get; set; }
    }

    public class GetTypesIntervenantsQuery : IQuery<GetTypesIntervenantsQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetTypesIntervenantsQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetTypesIntervenantsQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Sejour/Sejour/queries/GetTypesIntervenantsQuery", AtHomeUrl)).Result;
            ActionResult<GetTypesIntervenantsQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetTypesIntervenantsQueryResult[]>>(taskResult);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
