using System;

namespace Arcan.AtHome.API.Implementation.Queries
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
}
