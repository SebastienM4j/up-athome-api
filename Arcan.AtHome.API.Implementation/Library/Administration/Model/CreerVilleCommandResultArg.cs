namespace Arcan.AtHome.API.Implementation.Queries
{
    public class CreerVilleCommandArg
    {
        public string CodePostal { get; set; }
        public string villeNom { get; set; }
    }

    public class CreerVilleCommandResult
    {
        public decimal Id { get; set; }
        public string CodePostal { get; set; }
        public string Nom { get; set; }
        public string IsVisible { get; set; }
        public decimal? ZSPID { get; set; }
        public string JourLivraison { get; set; }
    }
}
