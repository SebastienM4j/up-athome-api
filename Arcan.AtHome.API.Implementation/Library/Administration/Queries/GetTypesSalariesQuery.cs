using System.Net.Http;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
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

    public class GetTypesSalariesQuery : AtHomeQuery<GetTypesSalariesQueryResult[]>
    {
        public GetTypesSalariesQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetTypesSalariesQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Administration/Salarie/queries/GetTypeSalarieQuery", AtHomeUrl)).Result;
            GetTypesSalariesQueryResult[] result = JsonConvert.DeserializeObject<GetTypesSalariesQueryResult[]>(taskResult);

            return result;
        }
    }
}
