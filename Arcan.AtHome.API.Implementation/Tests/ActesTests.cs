using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class ActesTests
    {
        [Fact]
        public void GetActes()
        {
            ActionResult<GetActesQueryResult[]> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<GetActesQueryResult[]>>(Urls.GetActes).Execute();

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            var entity = result.Entity;
            foreach (GetActesQueryResult acte in entity)
            {
                Assert.True(acte.ActeId != default(int));
                Assert.True(acte.TypeIntervenantId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(acte.Libelle));
            }
        }

        [Fact]
        public void GetActeParId()
        {
            ActionResult<GetActeParIdQueryResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<GetActeParIdQueryResult>, GetActeParIdQueryArg>(Urls.GetActeParId).Execute(new GetActeParIdQueryArg(){
                ActeId = 138
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            Assert.True(result.Entity.ActeId != default(int));
            Assert.True(result.Entity.TypeIntervenantId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity.Libelle));
        }
    }
}
