using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class DesaffecterHoraireDeTravailArgs
    {
        public decimal SalarieId { get; set; }

        public DateTime Date { get; set; }

        public Guid TypeHoraireDeTravailId { get; set; }

        public string HeureDebut { get; set; }

        public string HeureFin { get; set; }

    }
}