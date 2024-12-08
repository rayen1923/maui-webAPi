using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SharedModels
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<WeatherForecast>> GetWeatherAsync(string baseUrl)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7015/WeatherForecast");
            return JsonConvert.DeserializeObject<List<WeatherForecast>>(response);
        }
    }
}
