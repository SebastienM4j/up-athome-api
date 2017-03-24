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
            GetSalarieParIdQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetSalarieParIdQueryResult[], GetSalarieParIdQueryArg>(Urls.GetSalariesParIds).Execute(new GetSalarieParIdQueryArg(){
                SalarieIds = new decimal[] { 610 }
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
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            CreerSalarieCommand command = new CreerSalarieCommand(authResult.AtHomeUrl, authResult.Cookie);

            ActionResult<CreerSalarieCommandResult> result = command.Execute(new CreerSalarieCommandArg()
            {
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
