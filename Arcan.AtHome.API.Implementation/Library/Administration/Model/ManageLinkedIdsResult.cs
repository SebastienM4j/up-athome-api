namespace Arcan.AtHome.API.Implementation.Commands
{
  public enum AtHomeEntityType
    {
        Utilisateur,
        TypeSalarie,
        Patient,
        Salarie,
        Antenne,
    }
 
 public class ManageLinkedIdsArg
    {
        public AtHomeEntityType AtHomeEntityType { get;  set; }
        public string ExternalSource { get;  set; }
        public bool AllEntity { get; set; }
        public bool Ajout { get; set; }
        public string ExternalSofware { get; set; }
        public string ExternalType { get; set; }
        public string NewAtHomeId { get; set; }
        public string NewExternalId { get; set; }
    }

    public class ManageLinkedIdsResult
    {
        public string AtHomeEntityType { get; set; }
        public string AtHomeId { get; set; }
        public string AtHomeValue { get; set; }
        public string ExternalSource { get; set; }
        public string ExternalId { get; set; }
    }
}