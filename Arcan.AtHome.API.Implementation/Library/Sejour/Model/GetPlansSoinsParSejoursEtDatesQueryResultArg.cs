using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetPlansSoinsParSejoursEtDatesQueryArg
    {
        public decimal[] SejourIds { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    }

    public class GetPlansSoinsParSejoursEtDatesQueryResult
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

    public class LignePlanSoins
    {
        public decimal LignePlanSoinsId { get; set; }
        public DayOfWeek Jour { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public bool Obligatoire { get; set; }
        public Acte[] Actes { get; set; }
    }

    public class Acte
    {
        public int ActeId { get; set; }
        public string Libelle { get; set; }
    }
}
