using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class AuthentificationTests
    {
        [Fact]
        public void AuthShouldSucceed()
        {
            AuthentificationQuery query = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = Credentials.UniqueCode,
                ApiKey = Credentials.ApiKey,
                ApiSecret = Credentials.ApiSecret
            };

            AuthentificationQueryResult result = query.Query(arg);

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Cookie));
            Assert.False(string.IsNullOrEmpty(result.AtHomeUrl));
        }

        [Fact]
        public void AuthShouldFail()
        {
            AuthentificationQuery query = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "1234567",
                ApiKey = "blablabla",
                ApiSecret = "lalala"
            };

            AuthentificationQueryResult result = query.Query(arg);

            Assert.Null(result);
        }
    }
}
