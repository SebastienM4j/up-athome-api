using System.Net.Http;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetCiviliteQueryResult
    {
        public decimal Id { get; set; }
        public string Libelle { get; set; }
        public string LibelleLong { get; set; }
    }

    public class GetCiviliteQuery : AtHomeQuery<GetCiviliteQueryResult[]>
    {
        public GetCiviliteQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public GetCiviliteQuery(string uniqueCode, string apiKey, string apiSecret) : base(uniqueCode, apiKey, apiSecret)
        {
        }

        public override GetCiviliteQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetCiviliteQuery", AtHomeUrl)).Result;
            GetCiviliteQueryResult[] result = JsonConvert.DeserializeObject<GetCiviliteQueryResult[]>(taskResult);

            return result;
        }
    }
}
