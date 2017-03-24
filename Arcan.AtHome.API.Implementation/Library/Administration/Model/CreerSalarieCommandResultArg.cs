using System;

namespace Arcan.AtHome.API.Implementation.Commands
{
    public enum SexeIds
    {
        Inconnu = 0,
        Masculin = 1,
        Feminin = 2,
    }

    public class CreerSalarieCommandArg
    {
        public string Matricule { get; set; }
        public decimal CiviliteId { get; set; }
        public string Nom { get; set; }
        public string NomJeuneFille { get; set; }
        public string Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public SexeIds SexeId { get; set; }
        public DateTime? DateDebutContrat { get; set; }
        public DateTime? DateFinContrat { get; set; }
        public string NumeroOfficielCarteCPE { get; set; }
        public decimal? FonctionId { get; set; }
        public string RPPS { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Adresse3 { get; set; }
        public string TelephoneFixe { get; set; }
        public string TelephonePortable { get; set; }
        public string NumeroPoste { get; set; }
        public decimal? AntenneId { get; set; }
        public decimal? VilleId { get; set; }
        public decimal TypeSalarieId { get; set; }
    }

    public class CreerSalarieCommandResult
    {
        public decimal SalariId { get; internal set; }
        public decimal UserId { get; internal set; }
    }
}
