using System;

namespace Library.RH.Model
{
    public class DesaffecterPassageATourneeCommandArgs
    {
        public Guid TourneeId { get; set; }
        
        public DateTime Date { get; set; }
        
        public decimal PassageId { get; set; }

        public bool EstPonctuel { get; set; }
    }
}
