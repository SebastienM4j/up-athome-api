using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Infrastructure;

namespace Arcan.AtHome.API.Queries
{
    public class GetPatientParIdsQueryArg
    {
        public decimal[] PatientIds { get; set; }
    }

    public class GetPatientParIdsQueryResult
    {
        public decimal PatientId { get; set; }
        public string IdentifiantExterne { get; set; }
        public string Sexe { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomJeuneFille { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string TelephoneFixe { get; set; }
        public string TelephonePortable { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

        public Adresse[] Adresses { get; set; }

        public class Adresse
        {
            public DateTime DateApplication { get; set; }
            public string Libelle { get; set; }
            public decimal VilleId { get; set; }
            public string VilleNom { get; set; }
            public string CodePostal { get; set; }
            public string Rue1 { get; set; }
            public string Rue2 { get; set; }
            public string Rue3 { get; set; }
            public string CEDEX { get; set; }
            public string TelephoneFixe { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            //Complement
            public string CodePorte { get; set; }
            public string Allee { get; set; }
            public string Entree { get; set; }
            public string Etage { get; set; }
            public bool Escalier { get; set; }
            public bool Ascenseur { get; set; }
        }
    }

    public class GetPatientParIdsQuery : IQuery<GetPatientParIdsQueryArg, GetPatientParIdsQueryResult[]>
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
        public GetPatientParIdsQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }
        public GetPatientParIdsQueryResult[] Query(GetPatientParIdsQueryArg arg)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", "ArcanCookieAuth=" + Cookie);
            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Patient/Patient/queries/GetPatientParIdsQuery", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<GetPatientParIdsQueryResult[]> result = JsonConvert.DeserializeObject<ActionResult<GetPatientParIdsQueryResult[]>>(responseBody);
            if (result == null || result.Succeeded == false)
                return null;

            return result.Entity;
        }
    }
}
