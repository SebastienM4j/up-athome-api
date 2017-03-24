using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using System;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class PlansSoinsTests
    {
        [Fact]
        public void GetPlansSoinsParSejourEtDates()
        {
            ActionResult<GetPlansSoinsParSejoursEtDatesQueryResult[]> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetPlansSoinsParSejoursEtDatesQueryResult[]>, GetPlansSoinsParSejoursEtDatesQueryArg>(Urls.GetPlansSoinsParSejoursEtDates).Execute(new GetPlansSoinsParSejoursEtDatesQueryArg(){
                SejourIds = new decimal[0],
                DateDebut = new DateTime(2017, 1, 1),
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            foreach (GetPlansSoinsParSejoursEtDatesQueryResult ps in result.Entity)
            {
                Assert.True(ps.PlanSoinsId != default(decimal));
                Assert.True(ps.SejourId != default(decimal));
                Assert.True(ps.DateDebut.HasValue);
                Assert.True(ps.TypeIntervenantId != default(decimal));

                foreach (LignePlanSoins ligne in ps.Lignes)
                {
                    Assert.True(ligne.LignePlanSoinsId != default(decimal));

                    foreach (Acte acte in ligne.Actes)
                    {
                        Assert.True(acte.ActeId != default(decimal));
                        Assert.False(string.IsNullOrWhiteSpace(acte.Libelle));
                    }
                }
            }
        }

        [Fact]
        public void GetPlansSoinsParId()
        {
            ActionResult<GetPlansSoinsParIdQueryResult> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetPlansSoinsParIdQueryResult>, GetPlansSoinsParIdQueryArg>(Urls.GetPlansSoinsParId).Execute(new GetPlansSoinsParIdQueryArg(){
                PlanSoinsId = 3294,
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            Assert.True(result.Entity.PlanSoinsId != default(decimal));
            Assert.True(result.Entity.SejourId != default(decimal));
            Assert.True(result.Entity.DateDebut.HasValue);
            Assert.True(result.Entity.TypeIntervenantId != default(decimal));

            foreach (LignePlanSoins ligne in result.Entity.Lignes)
            {
                Assert.True(ligne.LignePlanSoinsId != default(decimal));

                foreach (Acte acte in ligne.Actes)
                {
                    Assert.True(acte.ActeId != default(decimal));
                    Assert.False(string.IsNullOrWhiteSpace(acte.Libelle));
                }
            }
        }
    }
}
