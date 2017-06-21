using System;

namespace Library.Tournee
{
    public class GetTourneeParNomQueryArgs
    {
        public string Nom { get; set; }
    }

    public class GetTourneeParNomQueryResult
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
    }
}
