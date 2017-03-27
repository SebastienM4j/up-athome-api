using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class VillesTests
    {
        [Fact]
        public void GetVilles()
        {
            GetVillesParCodePostalQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetVillesParCodePostalQueryResult[], GetVillesParCodePostalQueryArg>(Urls.GetVillesParCodePostal).Execute(new GetVillesParCodePostalQueryArg()
            {
                CodePostal = "69001"
            });

            Assert.NotNull(result);

            Assert.True(result[0].Id != default(decimal));
            Assert.True(result[0].CodePostal == "69001");
            Assert.False(string.IsNullOrWhiteSpace(result[0].Nom));
            Assert.True(result[0].Nom.ToLower() == "lyon");
        }

        [Fact]
        public void CreerVille()
        {
            ActionResult<CreerVilleCommandResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<CreerVilleCommandResult>, CreerVilleCommandArg>(Urls.CreerVille).Execute(new CreerVilleCommandArg()
            {
                CodePostal = "69001",
                villeNom = "Gotham City 2"
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);
        }
    }
}
