using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class AuthentificationTests
    {
        [Fact]
        public void AuthShouldSucceed()
        {
            AuthentificationQuery query = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
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
