using Xunit;
using Arcan.AtHome.API.Implementation.Queries;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class ActesTests
    {
        [Fact]
        public void GetActes()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetActesQuery query = new GetActesQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetActesQueryResult[] result = query.Query();

            Assert.NotNull(result);

            foreach (GetActesQueryResult acte in result)
            {
                Assert.True(acte.ActeId != default(int));
                Assert.True(acte.TypeIntervenantId != default(decimal));
                Assert.False(string.IsNullOrWhiteSpace(acte.Libelle));
            }
        }

        [Fact]
        public void GetActeParId()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetActeParIdQuery query = new GetActeParIdQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetActeParIdQueryResult result = query.Query(new GetActeParIdQueryArg(){
                ActeId = 1
            });

            Assert.NotNull(result);

            Assert.True(result.ActeId != default(int));
            Assert.True(result.TypeIntervenantId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result.Libelle));
        }
    }
}
