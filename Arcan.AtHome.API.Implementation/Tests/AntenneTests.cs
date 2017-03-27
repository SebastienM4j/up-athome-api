using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class AntenneTests
    {
        [Fact]
        public void GetAntennes()
        {
            GetAntenneQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetAntenneQueryResult[]>(Urls.GetAntennes).Execute();

            Assert.NotNull(result);

            foreach (GetAntenneQueryResult antenne in result)
            {
                Assert.True(antenne.AntenneId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(antenne.RaisonSociale));
            }
        }

        [Fact]
        public void CreerAntenne()
        {
            ActionResult<decimal> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<decimal>, CreerAntenneCommandArg>(Urls.CreerAntenne).Execute(new CreerAntenneCommandArg() {
                EtablissementGeographiqueId = 1,
                RaisonSociale = "toujours raison",
                EstAntennePrincipale = true,
                Adresse1 = "adresse 1",
                VilleId = 29912,
                Livraison_VilleId = 29912
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);
        }
    }
}
