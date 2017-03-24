using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class FonctionsTests
    {
        [Fact]
        public void GetFonctions()
        {
            GetFonctionQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetFonctionQueryResult[]>(Urls.GetFonction).Execute();

            Assert.NotNull(result);

            foreach (GetFonctionQueryResult civilite in result)
            {
                Assert.True(civilite.Id != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(civilite.Libelle));
            }
        }
    }
}
