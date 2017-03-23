using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetTypesIntervenantsQueryResult
    {
        public decimal TypeIntervenantId { get; set; }
        public string Libelle { get; set; }
    }

    public class GetTypesIntervenantsQuery : AtHomeQuery<GetTypesIntervenantsQueryResult[]>
    {
        public GetTypesIntervenantsQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetTypesIntervenantsQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Sejour/Sejour/queries/GetTypesIntervenantsQuery", AtHomeUrl)).Result;
            ActionResult<GetTypesIntervenantsQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetTypesIntervenantsQueryResult[]>>(taskResult);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
