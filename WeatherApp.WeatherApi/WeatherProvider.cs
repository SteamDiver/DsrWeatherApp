using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.WeatherApi.Models;

namespace WeatherApp.WeatherApi
{
    public abstract class WeatherProvider
    {
        private string _language;
        private string _apiKey;
        private HttpClient _client;

        protected WeatherProvider(string controller)
        {
            _apiKey = ConfigurationManager.AppSettings.Get("apiKey");
            _language = ConfigurationManager.AppSettings.Get("apiLang");

            var baseUrl = new Uri(ConfigurationManager.AppSettings.Get("apiBaseUrl") + controller);
            _client = new HttpClient()
            {
                BaseAddress = baseUrl
            };
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        /// Performs get request to api base url for city 
        /// </summary>
        /// <param name="city">city</param>
        /// <returns>string json object</returns>
        protected async Task<string> DoGet(string city)
        {
            var uriBuilder = new UriBuilder(_client.BaseAddress);
            string args = $"key={_apiKey}&q={city}";
            uriBuilder.Query = args;

            var response = _client.GetAsync(uriBuilder.Uri).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }
}
