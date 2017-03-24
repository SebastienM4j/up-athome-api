using System;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public static class Urls
    {
        public const string GetAntennes = "api/Etablissement/Antenne/queries/GetAntenneQuery";
    }

    public class AtHomeClientFactory
    {
        private string _cookie;
        private string _atHomeUrl;
        private readonly string _uniqueCode;
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public AtHomeClientFactory(string uniqueCode, string apiKey, string apiSecret)
        {
            this._uniqueCode = uniqueCode;
            this._apiKey = apiKey;
            this._apiSecret = apiSecret;
        }

        protected bool Auth()
        {
            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = this._uniqueCode,
                ApiKey = this._apiKey,
                ApiSecret = this._apiKey
            };

            AuthentificationQueryResult authResult = new AuthentificationQuery().Query(arg);

            if (authResult != null)
            {
                this._cookie = authResult.Cookie;
                this._atHomeUrl = authResult.AtHomeUrl;
                return true;
            }

            return false;
        }

        public AtHomeClient<TResult, TArgs> Create<TResult, TArgs>(string apiUrl)
        {
            this.Auth();
            return (AtHomeClient<TResult, TArgs>)Activator.CreateInstance(typeof(AtHomeClient<TResult, TArgs>), this._atHomeUrl, apiUrl, this._cookie);
        }

        public AtHomeClient<TResult> Create<TResult>(string apiUrl)
        {
            this.Auth();
            return (AtHomeClient<TResult>)Activator.CreateInstance(typeof(AtHomeClient<TResult>), this._atHomeUrl, apiUrl, this._cookie);
        }
    }
}
