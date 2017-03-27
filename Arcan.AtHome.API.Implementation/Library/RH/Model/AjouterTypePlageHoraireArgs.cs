using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
  public class AjouterTypePlageHoraireArgs
    {
        public DateTime VersionDate { get; set; }

        public string LibelleLong { get; set; }

        public string LibelleCourt { get; set; }

        public bool Presence { get; set; }

        public bool ImpactCompteurs { get; set; }
    }

  
}
