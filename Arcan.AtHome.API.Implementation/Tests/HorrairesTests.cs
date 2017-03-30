
using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Commands;
using Arcan.AtHome.API.Implementation.Infrastructure;
using System;

namespace Arcan.AtHome.API.Implementation.Tests
{

    public class HorrairesTests{


        [Fact]
        public void AjouterTypePlageHoraireCommand()
        {
            string randomData = Guid.NewGuid().ToString();
            ActionResult<AjouterTypePlageHoraireResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AjouterTypePlageHoraireResult>, AjouterTypePlageHoraireArgs>(Urls.AjouterTypePlageHoraireCommand)
            .Execute(new AjouterTypePlageHoraireArgs(){
                 VersionDate = DateTime.Now, 
                LibelleLong = "testLibLong-" + randomData,
                LibelleCourt ="testLibCourt-" + randomData,
                Presence = true,
                ImpactCompteurs =true
            });

            Assert.Equal(true, result.Succeeded);
        }

        

        [Fact]
        public void AffecterHoraireDeTravailCommand()
        {
            string randomData = Guid.NewGuid().ToString();
            ActionResult<AjouterTypePlageHoraireResult> newTypePlageHorraire = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AjouterTypePlageHoraireResult>, AjouterTypePlageHoraireArgs>(Urls.AjouterTypePlageHoraireCommand)
            .Execute(new AjouterTypePlageHoraireArgs(){
                 VersionDate = DateTime.Now, 
                LibelleLong = "testLibLong-" + randomData,
                LibelleCourt ="testLibCourt-" + randomData,
                Presence = true,
                ImpactCompteurs =true
            });

           

            ActionResult<AffecterHoraireDeTravailCommandResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AffecterHoraireDeTravailCommandResult>, AffecterHoraireDeTravailCommandArgs>(Urls.AffecterHoraireDeTravailCommand)
            .Execute(new AffecterHoraireDeTravailCommandArgs(){
                SalarieId =442,
                Date = DateTime.Now,
                HeureDebut = new TimeSpan(9,0,0).ToString(),
                HeureFin = new TimeSpan(18,0,0).ToString() ,
                AntenneId = null,
                TypeHoraireDeTravailId = newTypePlageHorraire.Entity.Id
            });

            Assert.Equal(true, result.Succeeded);
            
        }
        
       

        [Fact]
        public void DesaffecterHoraireDeTravailCommand()
        {
            string randomData = Guid.NewGuid().ToString();

            ActionResult<AjouterTypePlageHoraireResult> newTypePlageHorraire = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AjouterTypePlageHoraireResult>, AjouterTypePlageHoraireArgs>(Urls.AjouterTypePlageHoraireCommand)
            .Execute(new AjouterTypePlageHoraireArgs(){
                 VersionDate = DateTime.Now, 
                LibelleLong = "testLibLong-" + randomData,
                LibelleCourt ="testLibCourt-" + randomData,
                Presence = true,
                ImpactCompteurs =true
            });

            ActionResult<AffecterHoraireDeTravailCommandResult> affectation = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AffecterHoraireDeTravailCommandResult>, AffecterHoraireDeTravailCommandArgs>(Urls.AffecterHoraireDeTravailCommand)
            .Execute(new AffecterHoraireDeTravailCommandArgs(){
                SalarieId =442,
                Date = DateTime.Now,
                HeureDebut = new TimeSpan(9,0,0).ToString(),
                HeureFin = new TimeSpan(18,0,0).ToString() ,
                AntenneId = null,
                TypeHoraireDeTravailId = newTypePlageHorraire.Entity.Id
            });



            ActionResult result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult,DesaffecterHoraireDeTravailArgs>(Urls.DesaffecterHoraireDeTravailCommand)
            .Execute(new DesaffecterHoraireDeTravailArgs(){
                    SalarieId =442,
                    Date = DateTime.Now,
                   TypeHoraireDeTravailId = newTypePlageHorraire.Entity.Id,
                   HeureDebut = new TimeSpan(9,0,0).ToString(),
                   HeureFin =new TimeSpan(18,0,0).ToString()
            });

            Assert.Equal(true, result.Succeeded);
        }


        [Fact]
        public void GetTypePlageHoraireParNomQuery()
        {



            string randomData = Guid.NewGuid().ToString();

            ActionResult<AjouterTypePlageHoraireResult> newTypePlageHorraire = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<ActionResult<AjouterTypePlageHoraireResult>, AjouterTypePlageHoraireArgs>(Urls.AjouterTypePlageHoraireCommand)
            .Execute(new AjouterTypePlageHoraireArgs(){
                 VersionDate = DateTime.Now, 
                LibelleLong = "testLibLong-" + randomData,
                LibelleCourt ="testLibCourt-" + randomData,
                Presence = true,
                ImpactCompteurs =true
            });

            GetTypePlageHoraireParNomResult result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret)
            .Create<GetTypePlageHoraireParNomResult, GetTypePlageHoraireParNomArgs>(Urls.GetTypePlageHoraireParNomQuery)
            .Execute(new GetTypePlageHoraireParNomArgs(){
                Libelle = "testLibLong-" + randomData,
            });

            Assert.Equal(newTypePlageHorraire.Entity.Id,result.Id);
        }


    }

}