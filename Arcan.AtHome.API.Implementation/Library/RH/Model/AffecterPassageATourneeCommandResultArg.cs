using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class AffecterPassageATourneeCommandArg
    {
        public Guid TourneeId { get; set; }

        public DateTime Date { get; set; }

        public decimal PassageId { get; set; }

        public bool EstPonctuel { get; set; }
    }
}
