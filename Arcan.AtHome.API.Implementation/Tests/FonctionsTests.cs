using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class FonctionsTests
    {
        [Fact]
        public void GetFonctions()
        {
            GetFonctionQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetFonctionQueryResult[]>(Urls.GetFonction).Execute();

            Assert.NotNull(result);

            foreach (GetFonctionQueryResult civilite in result)
            {
                Assert.True(civilite.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(civilite.Libelle));
            }
        }
    }
}
