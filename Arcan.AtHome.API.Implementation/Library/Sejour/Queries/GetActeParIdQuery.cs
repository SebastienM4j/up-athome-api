using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetActeParIdQueryArg
    {
        public int ActeId { get; set; }
    }

    public class GetActeParIdQueryResult
    {
        public decimal ActeId { get; set; }
        public string Libelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
    }

    public class GetActeParIdQuery : AtHomeQuery<GetActeParIdQueryArg, GetActeParIdQueryResult>
    {
        public GetActeParIdQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetActeParIdQueryResult Query(GetActeParIdQueryArg arg)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Sejour/Sejour/queries/GetActeParIdQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetActeParIdQueryResult> result = JsonConvert.DeserializeObject<ActionResult<GetActeParIdQueryResult>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
