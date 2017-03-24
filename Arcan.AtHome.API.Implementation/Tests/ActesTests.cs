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
            ActionResult<GetActesQueryResult[]> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetActesQueryResult[]>>(Urls.GetActes).Execute();

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
            ActionResult<GetActeParIdQueryResult> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetActeParIdQueryResult>, GetActeParIdQueryArg>(Urls.GetActeParId).Execute(new GetActeParIdQueryArg(){
                ActeId = 1
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            Assert.True(result.Entity.ActeId != default(int));
            Assert.True(result.Entity.TypeIntervenantId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity.Libelle));
        }
    }
}
