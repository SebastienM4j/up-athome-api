using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class CiviliteTests
    {
        [Fact]
        public void GetCivilites()
        {
            GetCiviliteQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetCiviliteQueryResult[]>(Urls.GetCivilite).Execute();

            Assert.NotNull(result);

            foreach (GetCiviliteQueryResult civilite in result)
            {
                Assert.True(civilite.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(civilite.Libelle));
                Assert.False(string.IsNullOrWhiteSpace(civilite.LibelleLong));
            }
        }
    }
}
