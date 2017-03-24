using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetPassagePonctuelParSejourEtDatesQueryArg
    {
        public decimal SejourId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

    }

    public class GetPassagePonctuelParSejourEtDatesQueryResult
    {
        public decimal Id { get; set; }
        public decimal SejourId { get; set; }
        public decimal TypeIntervenantId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public bool Obligatoire { get; set; }
        public string Commentaire { get; set; }
        public int[] ActeIds { get; set; }
    }
}
