using Arcan.AtHome.API.Implementation.Infrastructure;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Tests;
using Library.RH.Model;
using Library.Tournee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class TelevitaleTest
    {
        private const decimal SejourId1 = 1;
        private const decimal SejourId2 = 2;
        private DateTime Date = new DateTime(2017, 6, 19);
        private TimeSpan Debut = TimeSpan.FromHours(10);
        private TimeSpan Fin = TimeSpan.FromHours(11);
        private string Commentaire = "Coucou";
        private decimal TypeIntervenant = 12;
        private int[] ActeIds = new int[] { 135, 136 };
        private string NomTournee1 = "Tournée TV";
        private string NomTournee2 = "Tournée 2 TV";

        [Fact]
        public void ScenarioTournee()
        {
            AtHomeClientFactory factory = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret);

            //CREER PASSAGE 1
            ActionResult<CreerPassagePonctuelResult> creerPassagePonctuelResult = factory.Create<ActionResult<CreerPassagePonctuelResult>, CreerPassagePonctuelArg>(Urls.CreerPassagePonctuel).Execute(new CreerPassagePonctuelArg
            {
                SejourId = SejourId1,
                Date = Date,
                HeureDebut = Debut,
                HeureFin = Fin,
                Commentaire = Commentaire,
                Obligatoire = true,
                TypeIntervenantId = TypeIntervenant,
                ActeIds = ActeIds
            });
            decimal passagePonctuel1Id = creerPassagePonctuelResult.Entity.PassagePonctuelId;
            Assert.True(creerPassagePonctuelResult.Succeeded);

            //CREER PASSAGE 2
            ActionResult<CreerPassagePonctuelResult> creerPassagePonctuel2Result = factory.Create<ActionResult<CreerPassagePonctuelResult>, CreerPassagePonctuelArg>(Urls.CreerPassagePonctuel).Execute(new CreerPassagePonctuelArg
            {
                SejourId = SejourId2,
                Date = Date,
                HeureDebut = Debut,
                HeureFin = Fin,
                Commentaire = Commentaire,
                Obligatoire = true,
                TypeIntervenantId = TypeIntervenant,
                ActeIds = ActeIds
            });
            decimal passagePonctuel2Id = creerPassagePonctuel2Result.Entity.PassagePonctuelId;
            Assert.True(creerPassagePonctuel2Result.Succeeded);

            //CREER TOURNEE 1
            ActionResult<CreerTourneeCommandResult> creerTournee1Result = factory.Create<ActionResult<CreerTourneeCommandResult>, CreerTourneeCommandArgs>(Urls.CreerTournee).Execute(new CreerTourneeCommandArgs
            {
                Nom = NomTournee1,
                AntenneId = null
            });
            Assert.NotNull(creerTournee1Result);

            //CREER TOURNEE 2
            ActionResult<CreerTourneeCommandResult> creerTournee2Result = factory.Create<ActionResult<CreerTourneeCommandResult>, CreerTourneeCommandArgs>(Urls.CreerTournee).Execute(new CreerTourneeCommandArgs
            {
                Nom = NomTournee2,
                AntenneId = null
            });
            Assert.NotNull(creerTournee1Result);

            //GET TOURNEE 1
            GetTourneeParNomQueryResult[] getTournee1Result = factory.Create<GetTourneeParNomQueryResult[], GetTourneeParNomQueryArgs>(Urls.GetTourneeParNomQuery).Execute(new GetTourneeParNomQueryArgs { Nom = NomTournee1 });
            Assert.NotNull(getTournee1Result);
            Assert.True(getTournee1Result.Count() == 1);
            Guid tournee1Id = getTournee1Result.Single().Id;

            //GET TOURNEE 2
            GetTourneeParNomQueryResult[] getTournee2Result = factory.Create<GetTourneeParNomQueryResult[], GetTourneeParNomQueryArgs>(Urls.GetTourneeParNomQuery).Execute(new GetTourneeParNomQueryArgs { Nom = NomTournee2 });
            Assert.NotNull(getTournee1Result);
            Assert.True(getTournee2Result.Count() == 1);
            Guid tournee2Id = getTournee2Result.Single().Id;

            //AFFECTER PASSAGE 1 A TOURNEE 1
            ActionResult affecterPassageATournee1Result = factory.Create<ActionResult, AffecterPassageATourneeCommandArg>(Urls.AffecterPassageTournee).Execute(new AffecterPassageATourneeCommandArg
            {
                Date = Date,
                EstPonctuel = true,
                PassageId = passagePonctuel1Id,
                TourneeId = tournee1Id
            });
            Assert.True(affecterPassageATournee1Result.Succeeded);

            //AFFECTER PASSAGE 2 A TOURNEE 2
            ActionResult affecterPassageATournee2Result = factory.Create<ActionResult, AffecterPassageATourneeCommandArg>(Urls.AffecterPassageTournee).Execute(new AffecterPassageATourneeCommandArg
            {
                Date = Date,
                EstPonctuel = true,
                PassageId = passagePonctuel2Id,
                TourneeId = tournee2Id
            });
            Assert.True(affecterPassageATournee2Result.Succeeded);

            //CHECK CONTENU TOURNEE 1
            GetTourneeContenuParIdQueryResult[] getTourneeContenuParIdQueryResult1 = factory.Create<GetTourneeContenuParIdQueryResult[], GetTourneeContenuParIdQueryArgs>(Urls.GetTourneeContenuParIdQuery).Execute(new GetTourneeContenuParIdQueryArgs { Id = tournee1Id, Debut = Date, Fin = Date });

            Assert.True(getTourneeContenuParIdQueryResult1.Single().Passages.Count() == 1);
            Assert.True(getTourneeContenuParIdQueryResult1.Single().Passages.Single().PassageId == passagePonctuel1Id);

            //CHECK CONTENU TOURNEE 2
            GetTourneeContenuParIdQueryResult[] getTourneeContenuParIdQueryResult2 = factory.Create<GetTourneeContenuParIdQueryResult[], GetTourneeContenuParIdQueryArgs>(Urls.GetTourneeContenuParIdQuery).Execute(new GetTourneeContenuParIdQueryArgs { Id = tournee2Id, Debut = Date, Fin = Date });

            Assert.True(getTourneeContenuParIdQueryResult2.Single().Passages.Count() == 1);
            Assert.True(getTourneeContenuParIdQueryResult2.Single().Passages.Single().PassageId == passagePonctuel2Id);

            //DESAFFECTER PASSAGE 1 DE TOURNEE 1
            ActionResult desaffecterPassageResult = factory.Create<ActionResult, DesaffecterPassageATourneeCommandArgs>(Urls.DesaffecterPassageTournee).Execute(new DesaffecterPassageATourneeCommandArgs
            {
                Date = Date,
                EstPonctuel = true,
                PassageId = passagePonctuel1Id,
                TourneeId = tournee1Id
            });
            Assert.True(desaffecterPassageResult.Succeeded);

            //DESAFFECTER PASSAGE 2 DE TOURNEE 2
            ActionResult desaffecterPassageResult2 = factory.Create<ActionResult, DesaffecterPassageATourneeCommandArgs>(Urls.DesaffecterPassageTournee).Execute(new DesaffecterPassageATourneeCommandArgs
            {
                Date = Date,
                EstPonctuel = true,
                PassageId = passagePonctuel2Id,
                TourneeId = tournee2Id
            });
            Assert.True(desaffecterPassageResult2.Succeeded);

            //SUPPRIMER PASSAGE 1
            ActionResult supprimerPassagePonctuelCommandResult = factory.Create<ActionResult, SupprimerPassagePonctuelCommandArg>(Urls.SupprimerPassagePonctuel).Execute(new SupprimerPassagePonctuelCommandArg { PassagePonctuelId = passagePonctuel1Id });

            Assert.True(supprimerPassagePonctuelCommandResult.Succeeded);

            //SUPPRIMER PASSAGE 2
            ActionResult supprimerPassagePonctuelCommandResult2 = factory.Create<ActionResult, SupprimerPassagePonctuelCommandArg>(Urls.SupprimerPassagePonctuel).Execute(new SupprimerPassagePonctuelCommandArg { PassagePonctuelId = passagePonctuel2Id });

            Assert.True(supprimerPassagePonctuelCommandResult2.Succeeded);
        }
    }
}
