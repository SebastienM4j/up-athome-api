using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public static class Urls
    {
        public const string GetCivilite = "api/Administration/Salarie/queries/GetCiviliteQuery";
        public const string GetFonction = "api/Administration/Salarie/queries/GetFonctionQuery";
        public const string GetSalariesParIds = "api/Administration/Salarie/queries/GetSalarieParIdQuery";
        public const string GetTypesSalaries = "api/Administration/Salarie/queries/GetTypeSalarieQuery";
        public const string GetVillesParCodePostal = "api/Administration/Ville/queries/GetVilleParCodePostalQuery";
        public const string GetEtablissementGeographique = "api/Etablissement/Antenne/queries/GetEtablismentGeographiqueQuery";
        public const string GetAntennes = "api/Etablissement/Antenne/queries/GetAntenneQuery";
        public const string GetPatientParIds = "api/Patient/Patient/queries/GetPatientParIdsQuery";
        public const string GetActeParId = "api/Sejour/Sejour/queries/GetActeParIdQuery";
        public const string GetActes = "api/Sejour/Sejour/queries/GetActesQuery";
        public const string GetPassagePonctuelParSejourEtDate = "api/Sejour/PassagePonctuel/queries/GetPassagePonctuelParSejourEtDatesQuery";
        public const string GetPlansSoinsParId = "api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParIdQuery";
        public const string GetPlansSoinsParSejoursEtDates = "api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParSejoursEtDatesQuery";
        public const string GetSejourParIdExterne = "api/Sejour/Sejour/queries/GetSejourParIdExterneQuery";
        public const string GetSejoursParDate = "api/Sejour/Sejour/queries/GetSejoursParDateQuery";
        public const string GetTypesIntervenants = "api/Sejour/Sejour/queries/GetTypesIntervenantsQuery";

        public const string CreerSalarie = "api/Administration/Salarie/commands/CreerSalarieCommand/Execute";
        
        
        public const string AffecterHoraireDeTravailCommand = "api/RH/TimeSlot/commands/AffecterHoraireDeTravailCommand/Execute";
        public const string DesaffecterHoraireDeTravailCommand = "api/RH/TimeSlot/commands/DesaffecterHoraireDeTravailCommand/Execute";
        public const string AjouterTypePlageHoraireCommand = "api/RH/TimeSlot/commands/AjouterTypePlageHoraireCommand/Execute";
        public const string GetTypePlageHoraireParNomQuery = "api/RH/TimeSlot/queries/GetTypePlageHoraireParNomQuery";




        public const string UpdateSalarie = "api/Administration/Salarie/commands/UpdateSalarieCommand/Execute";
        public const string ManageLinkedIds = "api/Maintenance/LinkedId/commands/ManageLinkedIdsCommand/Execute";

        public const string CreerVille = "api/Administration/Ville/commands/CreateVilleCommand/Execute";
        public const string CreerAntenne = "api/Etablissement/Antenne/commands/CreerAntenneCommand/Execute";

        public const string CreerActe = "api/Sejour/Acte/commands/CreerActeCommand/Execute";
        public const string CreerVisiteSalarie = "api/Sejour/VisiteSalarie/commands/CreerVisiteSalarieCommand/Execute";
        public const string CreerPassagePonctuel = "api/Sejour/PassagePonctuel/commands/CreerPassagePonctuelCommand/Execute";
        public const string MettreAJourPassagePonctuel = "api/Sejour/PassagePonctuel/commands/MettreAJourPassagePonctuelCommand/Execute";
        public const string SupprimerPassagePonctuel = "api/Sejour/PassagePonctuel/commands/SupprimerPassagePonctuelCommand/Execute";

        public const string CreerTournee = "api/RH/Tour/commands/CreerTourneeCommand/Execute";
        public const string AffecteSalarieTournee = "api/RH/Tour/commands/AffecterSalarieATourneeCommand/Execute";
        public const string AffecterPassageTournee = "api/RH/Tour/commands/AffecterPassageATourneeCommand/Execute";
    }

    public class AtHomeClientFactory
    {
        private string _cookie;
        private string _atHomeUrl;
        private readonly string _uniqueCode;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public AtHomeClientFactory(string uniqueCode, string apiKey, string apiSecret)
        {
            this._uniqueCode = uniqueCode;
            this._apiKey = apiKey;
            this._apiSecret = apiSecret;
        }

        protected bool Auth()
        {
            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = this._uniqueCode,
                ApiKey = this._apiKey,
                ApiSecret = this._apiSecret
            };

            AuthentificationQueryResult authResult = new AuthentificationQuery().Query(arg);

            if (authResult != null)
            {
                this._cookie = authResult.Cookie;
                this._atHomeUrl = authResult.AtHomeUrl;
                return true;
            }

            return false;
        }

        public AtHomeClient<TResult, TArgs> Create<TResult, TArgs>(string apiUrl)
        {
            this.Auth();
            return (AtHomeClient<TResult, TArgs>)Activator.CreateInstance(typeof(AtHomeClient<TResult, TArgs>), this._atHomeUrl, apiUrl, this._cookie);
        }

        public AtHomeClient<TResult> Create<TResult>(string apiUrl)
        {
            this.Auth();
            return (AtHomeClient<TResult>)Activator.CreateInstance(typeof(AtHomeClient<TResult>), this._atHomeUrl, apiUrl, this._cookie);
        }
    }
}
