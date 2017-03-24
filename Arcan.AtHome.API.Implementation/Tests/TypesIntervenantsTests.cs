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
            ActionResult<GetTypesIntervenantsQueryResult[]> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetTypesIntervenantsQueryResult[]>>(Urls.GetTypesIntervenants).Execute();

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
