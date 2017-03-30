using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class AffecterHoraireDeTravailCommandArgs
    {
        public decimal SalarieId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan HeureDebut { get; set; }

        public TimeSpan HeureFin { get; set; }

        public decimal? AntenneId { get; set; }

        public Guid TypeHoraireDeTravailId { get; set; }
   
    }
}