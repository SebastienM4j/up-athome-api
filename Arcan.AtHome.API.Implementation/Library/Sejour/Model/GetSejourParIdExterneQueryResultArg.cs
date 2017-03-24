using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class GetSejoursParIdExterneQueryArg
    {
        public string IdentifiantExterne { get; set; }
    }

    public class GetSejoursParIdExterneQueryResult
    {
        public decimal SejourId { get; set; }
        public string IdentifiantExterne { get; set; }
        public decimal PatientId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateDebutPrevisionnel { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateFinPrevisionnelle { get; set; }
        public decimal? AntenneId { get; set; }
        public string AntenneNom { get; set; }
        public decimal? UniteServiceId { get; set; }
        public string UniteServiceNom { get; set; }
    }
}
