using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class TypesSalariesTests
    {
        [Fact]
        public void GetTypesSalaries()
        {
            GetTypesSalariesQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetTypesSalariesQueryResult[]>(Urls.GetTypesSalaries).Execute();

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
