namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetVillesParCodePostalQueryArg
    {
        public string CodePostal { get; set; }
    }

    public class GetVillesParCodePostalQueryResult
    {
        public decimal Id { get; set; }
        public string CodePostal { get; set; }
        public string JourLivraison { get; set; }
        public string Nom { get; set; }
        public decimal? ZSPID { get; set; }
    }
}
