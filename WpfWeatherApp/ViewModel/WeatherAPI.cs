using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfWeatherApp.Model;

namespace WpfWeatherApp.ViewModel
{
    public class WeatherAPI
    {
        public const string APIKEY = "Ga8WJcJRAkeFKEFslCgbEJtK5KuQcAl0";
        public const string BASEURL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{cityCode}?apikey={apiKey}&language=pl&metric=true";

        /// <summary>
        /// Zwraca informacje o pogodzie dla podanego miasta
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public async Task<AccuWeather> GetWeatherInformationAsync(string cityCode)
        {
            AccuWeather result = new AccuWeather();

            string url = BASEURL
                .Replace("{cityCode}", cityCode.ToString())
                .Replace("{apiKey}", APIKEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<AccuWeather>(json);
            }

            return result;
        }

        /*
        /// <summary>
        /// Zwraca kod miasta z API dla podanej nazwy
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        private int GetCityCode(string cityName)
        {
            //TODO - implementacja
            return 275781; //zwraca kod dla Katowice
        }
        */
    }
}
