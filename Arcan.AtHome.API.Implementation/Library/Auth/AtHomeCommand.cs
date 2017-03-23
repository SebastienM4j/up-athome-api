using System;
using System.Net;
using System.Net.Http;
using Arcan.AtHome.API.Implementation.Queries;
using Arcan.AtHome.API.Implementation.Infrastructure;

namespace Arcan.AtHome.API.Implementation.Commands
{
    public abstract class AtHomeCommand
    {
        protected string Cookie;
        protected string AtHomeUrl;
        protected string UniqueCode;
        protected string ApiKey;
        protected string ApiSecret;

        public AtHomeCommand()
        {
        }

        public AtHomeCommand(string uniqueCode, string apiKey, string apiSecret)
        {
            this.UniqueCode = uniqueCode;
            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;
        }

        public AtHomeCommand(string atHomeUrl, string cookie)
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
            cookies.Add(new Uri(AtHomeUrl), cookie);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            HttpClient client = new HttpClient(handler);

            return client;
        }
    }

    public abstract class AtHomeCommand<TResult> : AtHomeCommand, ICommandWithResult<TResult>
    {
        public AtHomeCommand() : base()
        {
        }

        public AtHomeCommand(string uniqueCode, string apiKey, string apiSecret) : base(uniqueCode, apiKey, apiSecret)
        {
        }

        public AtHomeCommand(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public abstract CanExecuteResult CanExecute();
        public abstract ActionResult<TResult> Execute();
    }

    public abstract class AtHomeCommand<TArgs, TResult> : AtHomeCommand, ICommandWithResult<TArgs, TResult>
    {
        public AtHomeCommand() : base()
        {
        }

        public AtHomeCommand(string uniqueCode, string apiKey, string apiSecret) : base(uniqueCode, apiKey, apiSecret)
        {
        }

        public AtHomeCommand(string atHomeUrl, string cookie) : base(atHomeUrl, cookie)
        {
        }

        public abstract CanExecuteResult CanExecute(TArgs args);
        public abstract ActionResult<TResult> Execute(TArgs args);
    }
}