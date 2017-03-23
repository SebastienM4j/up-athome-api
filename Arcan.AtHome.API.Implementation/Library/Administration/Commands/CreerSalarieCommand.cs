using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Commands
{
    public enum SexeIds
    {
        Inconnu = 0,
        Masculin = 1,
        Feminin = 2,
    }

    public class CreerSalarieCommandArg
    {
        public string Matricule { get; set; }
        public decimal CiviliteId { get; set; }
        public string Nom { get; set; }
        public string NomJeuneFille { get; set; }
        public string Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public SexeIds SexeId { get; set; }
        public DateTime? DateDebutContrat { get; set; }
        public DateTime? DateFinContrat { get; set; }
        public string NumeroOfficielCarteCPE { get; set; }
        public decimal? FonctionId { get; set; }
        public string RPPS { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Adresse3 { get; set; }
        public string TelephoneFixe { get; set; }
        public string TelephonePortable { get; set; }
        public string NumeroPoste { get; set; }
        public decimal? AntenneId { get; set; }
        public decimal? VilleId { get; set; }
        public decimal TypeSalarieId { get; set; }
    }

    public class CreerSalarieCommandResult
    {
        public decimal SalariId { get; internal set; }
        public decimal UserId { get; internal set; }
    }

    public class CreerSalarieCommand : AtHomeCommand<CreerSalarieCommandArg, CreerSalarieCommandResult>
    {
        public CreerSalarieCommand(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public override CanExecuteResult CanExecute(CreerSalarieCommandArg arg)
        {
            return new CanExecuteResult(true);
        }

        public override ActionResult<CreerSalarieCommandResult> Execute(CreerSalarieCommandArg arg)
        {
            CanExecuteResult canExecuteResult = this.CanExecute(arg);
            if (canExecuteResult.CanExecute == false)
                return new ActionResult<CreerSalarieCommandResult>(false, null, canExecuteResult.Messages);

            HttpClient client = GetRESTClient();
            if (client == null)
                return null;

            StringContent body = new StringContent(JsonConvert.SerializeObject(arg), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}api/Administration/Salarie/commands/CreerSalarieCommand/Execute", AtHomeUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<CreerSalarieCommandResult> result = JsonConvert.DeserializeObject<ActionResult<CreerSalarieCommandResult>>(responseBody);
            return result;
        }
    }
}
