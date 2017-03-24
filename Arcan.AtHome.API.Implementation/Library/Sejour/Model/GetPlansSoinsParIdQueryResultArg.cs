using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetPlansSoinsParIdQueryArg
    {
        public decimal PlanSoinsId { get; set; }
    }

    public class GetPlansSoinsParIdQueryResult
    {
        public decimal PlanSoinsId { get; set; }
        public decimal SejourId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateFinPrevisonnelle { get; set; }
        public decimal TypeIntervenantId { get; set; }
        public string TypeIntervenantLibelle { get; set; }
        public LignePlanSoins[] Lignes { get; set; }
        public string Commentaire { get; set; }
    }
}
