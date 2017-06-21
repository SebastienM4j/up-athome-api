using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Tests;
using Library.Tournee;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TourneeTests
    {
        [Fact]
        public void GetTourneeContenuParIdQuery()
        {
            GetTourneeContenuParIdQueryResult result = new AtHomeClientFactory(Credentials.UniqueCode, Credentials.ApiKey, Credentials.ApiSecret).Create<GetTourneeContenuParIdQueryResult, GetTourneeContenuParIdQueryArgs>(Urls.GetActeParId).Execute(new GetTourneeContenuParIdQueryArgs
            {
                Id = Guid.Parse("32B26359-417A-4690-BD8C-0AF2D4F8EDA0"),
                Debut = new DateTime(2017, 06, 19),
                Fin = new DateTime(2017, 06, 19)
            });
        }
    }
}
