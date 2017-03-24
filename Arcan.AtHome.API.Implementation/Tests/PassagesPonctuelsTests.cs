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
            GetPassagePonctuelParSejourEtDatesQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetPassagePonctuelParSejourEtDatesQueryResult[], GetPassagePonctuelParSejourEtDatesQueryArg>(Urls.GetPassagePonctuelParSejourEtDate).Execute(new GetPassagePonctuelParSejourEtDatesQueryArg()
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
