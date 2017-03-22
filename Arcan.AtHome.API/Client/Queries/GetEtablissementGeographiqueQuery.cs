using System.Net.Http;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetEtablissementGeographiqueQueryResult
    {
        public decimal EtablissementGeographiqueId { get; set; }
        public string Libelle { get; set; }
    }

    public class GetEtablissementGeographiqueQuery : IQuery<GetEtablissementGeographiqueQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetEtablissementGeographiqueQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetEtablissementGeographiqueQueryResult[] Query()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);

            string taskResult = client.GetStringAsync(string.Format("{0}api/Etablissement/Antenne/queries/GetEtablismentGeographiqueQuery", AtHomeUrl)).Result;
            GetEtablissementGeographiqueQueryResult[] result = JsonConvert.DeserializeObject<GetEtablissementGeographiqueQueryResult[]>(taskResult);

            return result;
        }
    }
}
