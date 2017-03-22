using Xunit;
using Arcan.AtHome.API.Queries;
using System;

namespace Arcan.AtHome.API.Tests
{
    public class PassagesPonctuelsTests
    {
        [Fact]
        public void GetPassagePonctuelParSejourEtDates()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetPassagePonctuelParSejourEtDatesQuery query = new GetPassagePonctuelParSejourEtDatesQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetPassagePonctuelParSejourEtDatesQueryResult[] result = query.Query(new GetPassagePonctuelParSejourEtDatesQueryArg()
            {
                SejourId = 6248,
                DateDebut = new DateTime(2017, 1, 1)
            });

            Assert.NotNull(result);

            foreach (GetPassagePonctuelParSejourEtDatesQueryResult passage in result)
            {
                Assert.True(passage.Id != default(decimal));
                Assert.True(passage.SejourId != default(decimal));
            }
        }
    }
}
