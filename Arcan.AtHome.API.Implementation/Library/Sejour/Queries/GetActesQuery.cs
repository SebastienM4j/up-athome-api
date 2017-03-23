using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetActesQueryResult
    {
        public int ActeId { get; set; }
        public string Libelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
    }

    public class GetActesQuery : AtHomeQuery<GetActesQueryResult[]>
    {
        public GetActesQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetActesQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Sejour/Sejour/queries/GetActesQuery", AtHomeUrl)).Result;
            ActionResult<GetActesQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetActesQueryResult[]>>(taskResult);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
