using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class VillesTests
    {
        [Fact]
        public void GetVilles()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetVillesParCodePostalQuery query = new GetVillesParCodePostalQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetVillesParCodePostalQueryResult[] result = query.Query(new GetVillesParCodePostalQueryArg()
            {
                CodePostal = "69001"
            });

            Assert.NotNull(result);
            Assert.True(result.Length == 1);

            Assert.True(result[0].Id != default(decimal));
            Assert.True(result[0].CodePostal == "69001");
            Assert.False(string.IsNullOrWhiteSpace(result[0].Nom));
            Assert.True(result[0].Nom.ToLower() == "lyon");
        }
    }
}
