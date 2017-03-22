using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetSalarieParIdQueryArg
    {
        public decimal[] SalarieIds { get; set; }
    }

    public class GetSalarieParIdQueryResult
    {
        public decimal Id { get; set; }
        public string Matricule { get; set; }
        public decimal? CiviliteId { get; set; }
        public string Nom { get; set; }
        public string NomJeuneFille { get; set; }
        public string Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public decimal? SexeId { get; set; }
        public decimal TypeSalarieId { get; set; }
        public decimal? AntenneId { get; set; }
        public DateTime? DateDebutContrat { get; set; }
        public DateTime? DateFinContrat { get; set; }
        public decimal? BinomeId { get; set; }
        public decimal? SecteurSalarieId { get; set; }
        public string NumeroOfficielCarteCPE { get; set; }
        public decimal? FonctionId { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Adresse3 { get; set; }
        public string TelephoneFixe { get; set; }
        public string TelephonePortable { get; set; }
        public string NumeroPoste { get; set; }
        public decimal? VilleId { get; set; }
    }

    public class GetSalarieParIdQuery : IQuery<GetSalarieParIdQueryArg, GetSalarieParIdQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetSalarieParIdQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetSalarieParIdQueryResult[] Query(GetSalarieParIdQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Administration/Salarie/queries/GetSalarieParIdQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            GetSalarieParIdQueryResult[] result = JsonConvert.DeserializeObject<GetSalarieParIdQueryResult[]>(responseBody);

            return result;
        }
    }
}
