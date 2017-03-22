using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class AntenneTests
    {
        [Fact]
        public void GetAntennes()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetAntenneQuery query = new GetAntenneQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetAntenneQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetAntenneQueryResult antenne in result)
            {
                Assert.True(antenne.AntenneId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(antenne.RaisonSociale));
            }
        }
    }
}
