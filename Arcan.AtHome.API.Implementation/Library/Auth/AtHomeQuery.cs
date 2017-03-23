using System;
using System.Net;
using System.Net.Http;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public abstract class AtHomeQuery
    {
        protected string Cookie;
        protected string AtHomeUrl;
        protected string UniqueCode;
        protected string ApiKey;
        protected string ApiSecret;

        public AtHomeQuery()
        {
        }

        public AtHomeQuery(string uniqueCode, string apiKey, string apiSecret)
        {
            this.UniqueCode = uniqueCode;
            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;
        }

        public AtHomeQuery(string atHomeUrl, string cookie)
        {
            this.AtHomeUrl = atHomeUrl;
            this.Cookie = cookie;
        }

        protected bool Auth()
        {
            AuthentificationQuery authQuery = new AuthentificationQuery();

            AuthentificationQueryArg arg = new AuthentificationQueryArg()
            {
                UniqueCode = UniqueCode,
                ApiKey = ApiKey,
                ApiSecret = ApiSecret
            };

            AuthentificationQueryResult authResult = authQuery.Query(arg);

            if (authQuery != null)
            {
                Cookie = authResult.Cookie;
                AtHomeUrl = authResult.AtHomeUrl;
                return true;
            }

            return false;
        }

        protected bool EnsureAuth()
        {
            if (Cookie == null)
            {
                bool authed = Auth();
                return authed;
            }

            return true;
        }

        protected HttpClient GetRESTClient()
        {
            if (EnsureAuth() == false)
            {
                return null;
            }

            CookieContainer cookies = new CookieContainer();
            Cookie cookie = new Cookie("ArcanCookieAuth", Cookie);
            /*{
                Domain = new Uri(AtHomeUrl).Host
            };*/
            cookies.Add(new Uri(AtHomeUrl), cookie);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            HttpClient client = new HttpClient(handler);

            return client;
        }
    }

    public abstract class AtHomeQuery<TResult> : AtHomeQuery, IQuery<TResult>
    {
        public AtHomeQuery()
        {
        }

        public AtHomeQuery(string uniqueCode, string apiKey, string apiSecret) : base(uniqueCode, apiKey, apiSecret)
        {
        }

        public AtHomeQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public virtual TResult Query()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AtHomeQuery<TArgs, TResult> : AtHomeQuery, IQuery<TArgs, TResult>
    {
        public AtHomeQuery()
        {
        }

        public AtHomeQuery(string uniqueCode, string apiKey, string apiSecret) : base(uniqueCode, apiKey, apiSecret)
        {
        }

        public AtHomeQuery(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public virtual TResult Query(TArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
