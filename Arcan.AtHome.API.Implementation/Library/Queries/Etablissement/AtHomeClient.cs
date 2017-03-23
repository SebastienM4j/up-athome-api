using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public class AtHomeClient<TResult>
    {
        private readonly string _atHomeUrl;
        private readonly string _cookie;
        private readonly string _apiUrl;

        public AtHomeClient(string atHomeUrl, string apiUrl, string cookie)
        {
            if (string.IsNullOrWhiteSpace(atHomeUrl))
                throw new Exception();

            if (string.IsNullOrWhiteSpace(apiUrl))
                throw new Exception();

            if (string.IsNullOrWhiteSpace(cookie))
                throw new Exception();

            this._atHomeUrl = atHomeUrl;
            this._apiUrl = apiUrl;
            this._cookie = cookie;
        }

        public TResult Execute()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return default(TResult);

            string taskResult = client.GetStringAsync(string.Format("{0}{1}", this._atHomeUrl, this._apiUrl)).Result;
            TResult result = JsonConvert.DeserializeObject<TResult>(taskResult);

            return result;
        }

        private HttpClient GetRESTClient()
        {
            CookieContainer cookies = new CookieContainer();
            Cookie cookie = new Cookie("ArcanCookieAuth", this._cookie);
            cookies.Add(new Uri(this._atHomeUrl), cookie);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            return new HttpClient(handler);
        }

    }

    public abstract class AtHomeClient<TResult, Targs>
    {
        private readonly string _atHomeUrl;
        private readonly string _cookie;
        private readonly string _apiUrl;

        public AtHomeClient(string atHomeUrl, string apiUrl, string cookie)
        {
            if (string.IsNullOrWhiteSpace(atHomeUrl))
                throw new Exception();

            if(string.IsNullOrWhiteSpace(apiUrl))
                throw new Exception();

            if (string.IsNullOrWhiteSpace(cookie))
                throw new Exception();

            this._atHomeUrl = atHomeUrl;
            this._apiUrl = apiUrl;
            this._cookie = cookie;
        }
        

        public TResult Execute(Targs args)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return default(TResult);

            string taskResult = client.GetStringAsync(string.Format("{0}{1}", this._atHomeUrl, this._apiUrl)).Result;
            TResult result = JsonConvert.DeserializeObject<TResult>(taskResult);

            return result;
        }

        private HttpClient GetRESTClient()
        {            
            CookieContainer cookies = new CookieContainer();
            Cookie cookie = new Cookie("ArcanCookieAuth", this._cookie);
            cookies.Add(new Uri(this._atHomeUrl), cookie);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            return new HttpClient(handler);
        }

    }
}
