using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using System;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class SejoursTests
    {
        [Fact]
        public void GetSejoursParDate()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetSejoursParDateQuery query = new GetSejoursParDateQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetSejoursParDateQueryResult[] result = query.Query(new GetSejoursParDateQueryArg()
            {
                DateDebut = new DateTime(2017, 1, 1),
                DateFin = new DateTime(2017, 6, 1),
            });

            Assert.NotNull(result);

            foreach (GetSejoursParDateQueryResult sejour in result)
            {
                Assert.True(sejour.SejourId != default(decimal));
                Assert.True(sejour.PatientId != default(decimal));
                Assert.True(sejour.DateDebut.HasValue);
            }
        }

        [Fact]
        public void GetSejoursParIdExterne()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetSejoursParIdExterneQuery query = new GetSejoursParIdExterneQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetSejoursParIdExterneQueryResult result = query.Query(new GetSejoursParIdExterneQueryArg()
            {
                IdentifiantExterne = "123456789",
            });

            Assert.NotNull(result);

            Assert.True(result.SejourId != default(decimal));
            Assert.True(result.PatientId != default(decimal));
            Assert.True(result.DateDebut.HasValue);
        }
    }
}
