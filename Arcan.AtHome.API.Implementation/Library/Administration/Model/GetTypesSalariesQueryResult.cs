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
}
