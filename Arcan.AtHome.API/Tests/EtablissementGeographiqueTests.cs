using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class EtablissementGeographiqueTests
    {
        [Fact]
        public void GetEtablissementsGeographiques()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetEtablissementGeographiqueQuery query = new GetEtablissementGeographiqueQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetEtablissementGeographiqueQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetEtablissementGeographiqueQueryResult eta in result)
            {
                Assert.True(eta.EtablissementGeographiqueId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(eta.Libelle));
            }
        }
    }
}
