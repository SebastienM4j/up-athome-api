using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class AffecterSalarieATourneeCommandArg
    {
        public Guid TourneeId { get; set; }

        public DateTime DatePassage { get; set; }

        public decimal SalarieId { get; set; }

        public bool EstPonctuel { get; set; }
    }
}
