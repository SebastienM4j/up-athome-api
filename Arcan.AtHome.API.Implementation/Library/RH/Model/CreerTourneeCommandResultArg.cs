using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class CreerTourneeCommandArgs
    {
        public string Nom { get; set; }

        public decimal? AntenneId { get; set; }
    }

    public class CreerTourneeCommandResult
    {
        public Guid TourneeId { get; set; }
    }
}
