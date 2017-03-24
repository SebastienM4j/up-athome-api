using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Arcan.AtHome.API.Implementation.Queries
{
    public abstract class AtHomeClient
    {
        protected readonly string _atHomeUrl;
        protected readonly string _cookie;
        protected readonly string _apiUrl;

        public AtHomeClient(string atHomeUrl, string apiUrl, string cookie)
        {
            if (string.IsNullOrWhiteSpace(atHomeUrl))
                throw new Exception(string.Format("L'URL d'AtHome est invalide: {0}", atHomeUrl));

            if (string.IsNullOrWhiteSpace(apiUrl))
                throw new Exception(string.Format("L'URL d'API est invalide: {0}", apiUrl));

            if (string.IsNullOrWhiteSpace(cookie))
                throw new Exception("Le cookie est invalide");

            this._atHomeUrl = atHomeUrl;
            this._apiUrl = apiUrl;
            this._cookie = cookie;
        }

        protected HttpClient GetRESTClient()
        {
            CookieContainer cookies = new CookieContainer();
            Cookie cookie = new Cookie("ArcanCookieAuth", this._cookie);
            cookies.Add(new Uri(this._atHomeUrl), cookie);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            return new HttpClient(handler);
        }
    }
    public class AtHomeClient<TResult> : AtHomeClient
    {
        public AtHomeClient(string atHomeUrl, string apiUrl, string cookie) : base(atHomeUrl, apiUrl, cookie) {}

        public TResult Execute()
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return default(TResult);

            string taskResult = client.GetStringAsync(string.Format("{0}{1}", this._atHomeUrl, this._apiUrl)).Result;
            TResult result = JsonConvert.DeserializeObject<TResult>(taskResult);

            return result;
        }
    }

    public class AtHomeClient<TResult, Targs> : AtHomeClient
    {
        public AtHomeClient(string atHomeUrl, string apiUrl, string cookie) : base(atHomeUrl, apiUrl, cookie) {}

        public TResult Execute(Targs args)
        {
            HttpClient client = GetRESTClient();
            if (client == null)
                return default(TResult);

            StringContent body = new StringContent(JsonConvert.SerializeObject(args), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(string.Format("{0}{1}", this._atHomeUrl, this._apiUrl), body).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return default(TResult);

            string responseBody = response.Content.ReadAsStringAsync().Result;
            TResult result = JsonConvert.DeserializeObject<TResult>(responseBody);
            
            return result;
        }
    }
}
