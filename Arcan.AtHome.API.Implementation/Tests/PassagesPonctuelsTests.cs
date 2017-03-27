using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using System;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class PassagesPonctuelsTests
    {
        [Fact]
        public void GetPassagePonctuelParSejourEtDates()
        {
            GetPassagePonctuelParSejourEtDatesQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetPassagePonctuelParSejourEtDatesQueryResult[], GetPassagePonctuelParSejourEtDatesQueryArg>(Urls.GetPassagePonctuelParSejourEtDate).Execute(new GetPassagePonctuelParSejourEtDatesQueryArg()
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
