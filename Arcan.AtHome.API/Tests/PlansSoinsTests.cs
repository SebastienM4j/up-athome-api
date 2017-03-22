using Xunit;
using Arcan.AtHome.API.Queries;
using System;

namespace Arcan.AtHome.API.Tests
{
    public class PlansSoinsTests
    {
        [Fact]
        public void GetPlansSoinsParSejourEtDates()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetPlansSoinsParSejoursEtDatesQuery query = new GetPlansSoinsParSejoursEtDatesQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetPlansSoinsParSejoursEtDatesQueryResult[] result = query.Query(new GetPlansSoinsParSejoursEtDatesQueryArg()
            {
                SejourIds = new decimal[0],
                DateDebut = new DateTime(2017, 1, 1),
            });

            Assert.NotNull(result);

            foreach (GetPlansSoinsParSejoursEtDatesQueryResult ps in result)
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
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetPlansSoinsParIdQuery query = new GetPlansSoinsParIdQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetPlansSoinsParIdQueryResult result = query.Query(new GetPlansSoinsParIdQueryArg()
            {
                PlanSoinsId = 3294,
            });

            Assert.NotNull(result);

            Assert.True(result.PlanSoinsId != default(decimal));
            Assert.True(result.SejourId != default(decimal));
            Assert.True(result.DateDebut.HasValue);
            Assert.True(result.TypeIntervenantId != default(decimal));

            foreach (LignePlanSoins ligne in result.Lignes)
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
