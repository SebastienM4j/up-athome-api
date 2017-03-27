using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class TypesSalariesTests
    {
        [Fact]
        public void GetTypesSalaries()
        {
            GetTypesSalariesQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetTypesSalariesQueryResult[]>(Urls.GetTypesSalaries).Execute();

            Assert.NotNull(result);

            foreach (GetTypesSalariesQueryResult typeSal in result)
            {
                Assert.True(typeSal.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(typeSal.Libelle));
                Assert.False(string.IsNullOrWhiteSpace(typeSal.Color));
            }
        }
    }
}
