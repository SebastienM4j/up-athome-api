using Xunit;
using Arcan.AtHome.API.Queries;

namespace Arcan.AtHome.API.Tests
{
    public class PatientsTests
    {
        [Fact]
        public void GetPatients()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = "9999999",
                ApiKey = "PECHAD",
                ApiSecret = "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630"
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            GetPatientParIdsQuery query = new GetPatientParIdsQuery(authResult.AtHomeUrl, authResult.Cookie);

            GetPatientParIdsQueryResult[] result = query.Query(new GetPatientParIdsQueryArg()
            {
                PatientIds = new decimal[] { 610 }
            });

            Assert.NotNull(result);
            Assert.True(result.Length == 1);

            Assert.True(result[0].PatientId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Sexe));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Civilite));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Nom));
            Assert.False(string.IsNullOrWhiteSpace(result[0].Prenom));
        }
    }
}
