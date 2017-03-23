using System.Net.Http;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetFonctionQueryResult
    {
        public decimal Id { get; set; }
        public string Libelle { get; set; }
    }

    public class GetFonctionQuery : AtHomeQuery<GetFonctionQueryResult[]>
    {
        public GetFonctionQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetFonctionQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetFonctionQuery", AtHomeUrl)).Result;
            GetFonctionQueryResult[] result = JsonConvert.DeserializeObject<GetFonctionQueryResult[]>(taskResult);

            return result;
        }
    }
}
