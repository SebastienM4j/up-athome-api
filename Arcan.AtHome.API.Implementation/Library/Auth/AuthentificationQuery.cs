using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net.Http.Headers;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class AuthentificationQueryArg
    {
        public string UniqueCode { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }

    public class AuthentificationQueryResult
    {
        public string AtHomeUrl { get; set; }
        public string Cookie { get; set; }
    }

    [DataContract]
    internal class AuthResult
    {
        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Saml { get; set; }
    }

    [DataContract]
    internal class LoginResult
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public bool Secure { get; set; }

        [DataMember]
        public bool Shareable { get; set; }

        [DataMember]
        public bool HttpOnly { get; set; }

        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public string Expires { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool HasKeys { get; set; }

        [DataMember]
        public string[] Values { get; set; }
    }

    public class AuthentificationQuery : IQuery<AuthentificationQueryArg, AuthentificationQueryResult>
    {
        public AuthentificationQueryResult Query(AuthentificationQueryArg arg)
        {
            // 1 Auth customers
            AuthResult authResult = AuthCustomers(arg.UniqueCode, arg.ApiKey, arg.ApiSecret);
            if (authResult == null)
            {
                //Console.WriteLine("Echec de l'authentification sur customers");
                return null;
            }

            // 2 Auth AtHome
            string cookie = AuthAtHome(authResult);
            if (string.IsNullOrWhiteSpace(cookie))
            {
                //Console.WriteLine("Echec de l'authentification sur AtHome");
                return null;
            }

            return new AuthentificationQueryResult()
            {
                AtHomeUrl = authResult.Url,
                Cookie = cookie
            };
        }

        private AuthResult AuthCustomers(string uniqueCode, string apiKey, string apiSecret)
        {
            HttpClient clientAuth = new HttpClient();

            string authTaskResult = clientAuth.GetStringAsync(string.Format("https://auth.arcan.fr/api/ApiLogin/GetAuthData?apiKey={0}&apiSecret={1}&uniqueCode={2}", apiKey, apiSecret, uniqueCode)).Result;
            ActionResult<AuthResult> authResult = JsonConvert.DeserializeObject<ActionResult<AuthResult>>(authTaskResult);

            if (authResult == null || authResult.Succeeded == false)
                return null;

            // TODO: delete
            authResult.Entity.Url = "http://192.168.1.89:2083/";
            return authResult.Entity;
        }

        private string AuthAtHome(AuthResult authResult)
        {
            HttpClient clientAtHome = new HttpClient();

            clientAtHome.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            dynamic samlArg = new System.Dynamic.ExpandoObject();
            samlArg.Saml = authResult.Saml;
            StringContent body = new StringContent(JsonConvert.SerializeObject(samlArg), Encoding.UTF8, "application/json");

            if (authResult.Url.EndsWith("/") == false)
                authResult.Url += "/";
            HttpResponseMessage response = clientAtHome.PostAsync(string.Format("{0}api/Authentification/Login", authResult.Url), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            string responseBody = response.Content.ReadAsStringAsync().Result;
            ActionResult<LoginResult> loginResult = JsonConvert.DeserializeObject<ActionResult<LoginResult>>(responseBody);
            if (loginResult == null || loginResult.Succeeded == false)
                return null;

            return loginResult.Entity.Value;
        }
    }
}
