using System.Net.Http;
using Newtonsoft.Json;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetEtablissementGeographiqueQueryResult
    {
        public decimal EtablissementGeographiqueId { get; set; }
        public string Libelle { get; set; }
    }

    public class GetEtablissementGeographiqueQuery : AtHomeQuery<GetEtablissementGeographiqueQueryResult[]>
    {
        public GetEtablissementGeographiqueQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }
        public override GetEtablissementGeographiqueQueryResult[] Query()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            string taskResult = client.GetStringAsync(string.Format("{0}api/Etablissement/Antenne/queries/GetEtablismentGeographiqueQuery", AtHomeUrl)).Result;
            GetEtablissementGeographiqueQueryResult[] result = JsonConvert.DeserializeObject<GetEtablissementGeographiqueQueryResult[]>(taskResult);

            return result;
        }
    }
}
