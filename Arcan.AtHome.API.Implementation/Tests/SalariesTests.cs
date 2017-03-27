using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Commands;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class SalariesTests
    {
        [Fact]
        public void GetSalaries()
        {
            GetSalarieParIdQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetSalarieParIdQueryResult[], GetSalarieParIdQueryArg>(Urls.GetSalariesParIds).Execute(new GetSalarieParIdQueryArg(){
                SalarieIds = new decimal[] { 442 }
            });

            Assert.NotNull(result);
            Assert.True(result.Length == 1);

            Assert.True(result[0].Id != default(decimal));
            Assert.True(result[0].TypeSalarieId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Nom));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Prenom));
        }

        [Fact]
        public void CreerSalarie()
        {
            ActionResult<CreerSalarieCommandResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<CreerSalarieCommandResult>, CreerSalarieCommandArg>(Urls.CreerSalarie).Execute(new CreerSalarieCommandArg(){
                Matricule = "123456789",
                CiviliteId = 1,
                Nom = "SalarieNOM",
                Prenom = "SalariePRENOM",
                SexeId = SexeIds.Feminin,
                Adresse1 = "salarie adresse 1",
                VilleId = 29912,
                TypeSalarieId = 22
            });

            Assert.NotNull(result);
        }
    }
}
