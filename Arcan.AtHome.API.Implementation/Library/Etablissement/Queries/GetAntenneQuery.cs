using System.Net.Http;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetAntenneQueryResult
    {
        public decimal AntenneId { get; set; }
        public string RaisonSociale { get; set; }
    }

    public class GetAntenneQuery : AtHomeQuery<GetAntenneQueryResult[]>
    {
        public GetAntenneQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetAntenneQueryResult[] Query()
        {
           HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Etablissement/Antenne/queries/GetAntenneQuery", AtHomeUrl)).Result;
            GetAntenneQueryResult[] result = JsonConvert.DeserializeObject<GetAntenneQueryResult[]>(taskResult);

            return result;
        }
    }
}
