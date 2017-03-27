using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class TypesIntervenantsTests
    {
        [Fact]
        public void GetTypesIntervenants()
        {
            ActionResult<GetTypesIntervenantsQueryResult[]> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<GetTypesIntervenantsQueryResult[]>>(Urls.GetTypesIntervenants).Execute();

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            foreach (GetTypesIntervenantsQueryResult typeInterv in result.Entity)
            {
                Assert.True(typeInterv.TypeIntervenantId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(typeInterv.Libelle));
            }
        }
    }
}
