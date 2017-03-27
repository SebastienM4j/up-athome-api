using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class CiviliteTests
    {
        [Fact]
        public void GetCivilites()
        {
            GetCiviliteQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetCiviliteQueryResult[]>(Urls.GetCivilite).Execute();

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
