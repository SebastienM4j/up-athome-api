using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class EtablissementGeographiqueTests
    {
        [Fact]
        public void GetEtablissementsGeographiques()
        {
            GetEtablissementGeographiqueQueryResult[] result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetEtablissementGeographiqueQueryResult[]>(Urls.GetEtablissementGeographique).Execute();

            Assert.NotNull(result);

            foreach (GetEtablissementGeographiqueQueryResult eta in result)
            {
                Assert.True(eta.EtablissementGeographiqueId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(eta.Libelle));
            }
        }
    }
}
