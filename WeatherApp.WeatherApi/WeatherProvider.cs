using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WeatherApp.WeatherApi
{
    public abstract class WeatherProvider
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;
        private readonly string _lang;

        protected WeatherProvider(string controller)
        {
            _apiKey = ConfigurationManager.AppSettings.Get("apiKey");
            _lang = ConfigurationManager.AppSettings.Get("apiLang");

            var baseUrl = new Uri(ConfigurationManager.AppSettings.Get("apiBaseUrl") + controller);
            _client = new HttpClient
            {
                BaseAddress = baseUrl
            };
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        ///     Performs get request to api base url for city with preconfigured base address, apiKey and lang
        /// </summary>
        /// <param name="city">city</param>
        /// <param name="optionalArgs">optional args</param>
        /// <returns>string json object</returns>
        protected async Task<string> DoGet(string city, string optionalArgs = "")
        {
            var uriBuilder = new UriBuilder(_client.BaseAddress);

            var args = $"key={_apiKey}&q={city}&lang={_lang}";

            if (!string.IsNullOrEmpty(optionalArgs))
                args += $"&{optionalArgs}";

            uriBuilder.Query = args;

            var response = _client.GetAsync(uriBuilder.Uri).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            return null;
        }
    }
}