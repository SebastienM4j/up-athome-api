using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class CiviliteTests
    {
        [Fact]
        public void GetCivilites()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetCiviliteQuery query = new GetCiviliteQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetCiviliteQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetCiviliteQueryResult civilite in result)
            {
                Assert.True(civilite.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(civilite.Libelle));
                Assert.False(string.IsNullOrWhiteSpace(civilite.LibelleLong));
            }
        }
    }
}
