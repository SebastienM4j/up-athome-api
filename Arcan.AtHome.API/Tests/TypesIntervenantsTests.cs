using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class TypesIntervenantsTests
    {
        [Fact]
        public void GetTypesIntervenants()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetTypesIntervenantsQuery query = new GetTypesIntervenantsQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetTypesIntervenantsQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetTypesIntervenantsQueryResult typeInterv in result)
            {
                Assert.True(typeInterv.TypeIntervenantId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(typeInterv.Libelle));
            }
        }
    }
}
