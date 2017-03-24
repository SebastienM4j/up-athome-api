namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetActeParIdQueryArg
    {
        public int ActeId { get; set; }
    }

    public class GetActeParIdQueryResult
    {
        public decimal ActeId { get; set; }
        public string Libelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
    }
}
