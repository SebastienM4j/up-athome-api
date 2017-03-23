using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class TypesSalariesTests
    {
        [Fact]
        public void GetTypesSalaries()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetTypesSalariesQuery query = new GetTypesSalariesQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetTypesSalariesQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetTypesSalariesQueryResult typeSal in result)
            {
                Assert.True(typeSal.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(typeSal.Libelle));
                Assert.False(string.IsNullOrWhiteSpace(typeSal.Color));
            }
        }
    }
}
