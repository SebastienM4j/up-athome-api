using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
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

    public class GetActeParIdQuery : IQuery<GetActeParIdQueryArg, GetActeParIdQueryResult>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetActeParIdQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetActeParIdQueryResult Query(GetActeParIdQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
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
