using Xunit;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Tests
{
    public class PatientsTests
    {
        [Fact]
        public void GetPatients()
        {
            ActionResult<GetPatientParIdsQueryResult[]> result = new AtHomeClientFactory("9999999", "PECHAD", "fe45086c02c374179f145d4e935a0cef64d8a801e7a2645ba01f8c4d7d230630").Create<ActionResult<GetPatientParIdsQueryResult[]>, GetPatientParIdsQueryArg>(Urls.GetPatientParIds).Execute(new GetPatientParIdsQueryArg(){
                PatientIds = new decimal[] { 610 }
            });

            Assert.NotNull(result);
            Assert.True(result.Succeeded);

            Assert.True(result.Entity[0].PatientId != default(decimal));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity[0].Sexe));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity[0].Civilite));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity[0].Nom));
            Assert.False(string.IsNullOrWhiteSpace(result.Entity[0].Prenom));
        }
    }
}
