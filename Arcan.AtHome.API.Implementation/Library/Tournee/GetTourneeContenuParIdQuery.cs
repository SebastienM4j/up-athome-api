using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tournee
{
    public class GetTourneeContenuParIdQueryArgs
    {
        public Guid Id { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }

    }
    public class GetTourneeContenuParIdQueryResult
    {
        public decimal[] Salaries { get; set; }
        public Passage[] Passages { get; set; }
        public DateTime VersionDate { get; set; }
        public bool Ponctuel { get; set; }
        public class Passage
        {
            public TimeSpan HeureDebut { get; set; }
            public TimeSpan HeureFin { get; set; }
            public decimal PassageId { get; set; }
        }
    }
}
