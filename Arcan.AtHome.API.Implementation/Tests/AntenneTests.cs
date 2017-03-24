using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class AntenneTests
    {
        [Fact]
        public void GetAntennes()
        {
            GetAntenneQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetAntenneQueryResult[]>(Urls.GetAntennes).Execute();

            Assert.NotNull(result);

            foreach (GetAntenneQueryResult antenne in result)
            {
                Assert.True(antenne.AntenneId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(antenne.RaisonSociale));
            }
        }
    }
}
