using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public static class Urls
    {
        public const string GetCivilite =                       "/api/domain/Salarie/GetCiviliteQuery";
        public const string GetFonction =                       "/api/domain/Salarie/GetFonctionQuery";
        public const string GetSalariesParIds =                 "/api/domain/Salarie/GetSalarieParIdQuery";
        public const string GetSalarieParUtilisateurId =        "/api/domain/Salarie/GetSalarieParUtilisateurIdQuery";
        public const string GetTypesSalaries =                  "/api/domain/Salarie/GetTypeSalarieQuery";        
        public const string GetEtablissementGeographique =      "/api/domain/Antenne/GetEtablismentGeographiqueQuery";
        public const string GetAntennes =                       "/api/domain/Antenne/GetAntenneQuery";
        public const string GetPatientParIds =                  "/api/domain/Patient/GetPatientParIdsQuery";
        public const string GetActeParId =                      "/api/domain/Sejour/GetActeParIdQuery";
        public const string GetActes =                          "/api/domain/Sejour/GetActesQuery";
        public const string GetPassagePonctuelParSejourEtDate = "/api/domain/PassagePonctuel/GetPassagePonctuelParSejourEtDatesQuery";
        public const string GetPlansSoinsParId =                "/api/domain/PlanSoinSalarie/GetPlansSoinsParIdQuery";
        public const string GetPlansSoinsParSejoursEtDates =    "/api/domain/PlanSoinSalarie/GetPlansSoinsParSejoursEtDatesQuery";
        public const string GetSejourParIdExterne =             "/api/domain/Sejour/GetSejourParIdExterneQuery";
        public const string GetSejoursParDate =                 "/api/domain/Sejour/GetSejoursParDateQuery";
        public const string GetTypesIntervenants =              "/api/domain/Sejour/GetTypesIntervenantsQuery";
        public const string CreerSalarie =                      "/api/domain/Salarie/CreerSalarieCommand/Execute";
        public const string AffecterHoraireDeTravailCommand =   "/api/domain/TimeSlot/AffecterHoraireDeTravailCommand/Execute";
        public const string DesaffecterHoraireDeTravailCommand ="/api/domain/TimeSlot/DesaffecterHoraireDeTravailCommand/Execute";
        public const string AjouterTypePlageHoraireCommand =    "/api/domain/TimeSlot/AjouterTypePlageHoraireCommand/Execute";
        public const string GetTypePlageHoraireParNomQuery =    "/api/domain/TimeSlot/GetTypePlageHoraireParNomQuery";
        public const string UpdateSalarie =                     "/api/domain/Salarie/UpdateSalarieCommand/Execute";
        public const string ManageLinkedIds =                   "/api/domain/LinkedId/ManageLinkedIdsCommand/Execute ";
        public const string CreerAntenne =                      "/api/domain/Antenne/CreerAntenneCommand/Execute";
        public const string CreerActe =                         "/api/domain/Acte/CreerActeCommand/Execute";
        public const string CreerVisiteSalarie =                "/api/domain/VisiteSalarie/CreerVisiteSalarieCommand/Execute";
        public const string CreerPassagePonctuel =              "/api/domain/PassagePonctuel/CreerPassagePonctuelCommand/Execute ";
        public const string MettreAJourPassagePonctuel =        "/api/domain/PassagePonctuel/MettreAJourPassagePonctuelCommand/Execute ";
        public const string SupprimerPassagePonctuel =          "/api/domain/PassagePonctuel/SupprimerPassagePonctuelCommand/Execute";
        public const string CreerTournee =                      "/api/domain/Tour/CreerTourneeCommand/Execute";
        public const string GetTourneeParNomQuery =             "/api/domain/Tour/GetTourneeParNomQuery";
        public const string GetTourneeContenuParIdQuery =       "/api/domain/Tour/GetTourneeContenuParIdQuery";
        public const string AffecteSalarieTournee =             "/api/domain/Tour/AffecterSalarieATourneeCommand/Execute";
        public const string AffecterPassageTournee =            "/api/domain/Tour/AffecterPassageATourneeCommand/Execute";
        public const string DesaffecterPassageTournee =         "/api/domain/Tour/DesaffecterPassageATourneeCommand/Execute";
        public const string CreerVille =                        "/api/domain/Ville/CreateVilleCommand/Execute";
        public const string GetVillesParCodePostal =            "/api/domain/Ville/GetVilleParCodePostalQuery";
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
