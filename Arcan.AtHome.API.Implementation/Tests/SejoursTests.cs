using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using System;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class SejoursTests
    {
        [Fact]
        public void GetSejoursParDate()
        {
            ActionResult<GetSejoursParDateQueryResult[]> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<GetSejoursParDateQueryResult[]>, GetSejoursParDateQueryArg>(Urls.GetSejoursParDate).Execute(new GetSejoursParDateQueryArg(){
                DateDebut = new DateTime(2017, 1, 1),
                DateFin = new DateTime(2017, 6, 1),
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            foreach (GetSejoursParDateQueryResult sejour in result.Entity)
            {
                Assert.True(sejour.SejourId != default(decimal));
                Assert.True(sejour.PatientId != default(decimal));
                Assert.True(sejour.DateDebut.HasValue);
            }
        }

        [Fact]
        public void GetSejoursParIdExterne()
        {
            ActionResult<GetSejoursParIdExterneQueryResult> result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<ActionResult<GetSejoursParIdExterneQueryResult>, GetSejoursParIdExterneQueryArg>(Urls.GetSejourParIdExterne).Execute(new GetSejoursParIdExterneQueryArg(){
                IdentifiantExterne = "123456789",
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            Assert.True(result.Entity.SejourId != default(decimal));
            Assert.True(result.Entity.PatientId != default(decimal));
            Assert.True(result.Entity.DateDebut.HasValue);
        }
    }
}
