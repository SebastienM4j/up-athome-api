using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class EtablissementGeographiqueTests
    {
        [Fact]
        public void GetEtablissementsGeographiques()
        {
            GetEtablissementGeographiqueQueryResult[] result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<GetEtablissementGeographiqueQueryResult[]>(Urls.GetEtablissementGeographique).Execute();

            Assert.NotNull(result);

            foreach (GetEtablissementGeographiqueQueryResult eta in result)
            {
                Assert.True(eta.EtablissementGeographiqueId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(eta.Libelle));
            }
        }
    }
}
