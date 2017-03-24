namespace Arcan.AtHome.API.Implementation.Queries
{
    public class CreerAntenneCommandArg
    {
        public decimal EtablissementGeographiqueId { get; set; }
        public string RaisonSociale { get; set; }
        public bool EstAntennePrincipale { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Adresse3 { get; set; }
        public decimal VilleId { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Livraison_RaisonSociale { get; set; }
        public string Livraison_Adresse1 { get; set; }
        public string Livraison_Adresse2 { get; set; }
        public string Livraison_Adresse3 { get; set; }
        public decimal? Livraison_VilleId { get; set; }
        public string Livraison_Telephone { get; set; }
        public string Livraison_Fax { get; set; }
    }
}
