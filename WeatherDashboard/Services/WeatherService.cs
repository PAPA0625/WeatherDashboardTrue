using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace WeatherDashboard.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["OpenWeatherMap:ApiKey"];
        }

        public async Task<JObject> GetWeatherAsync(string cityName)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&APPID={_apiKey}&units=metric&lang=zh_tw";
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                return JObject.Parse(response);
            }
            catch
            {
                return null;
            }
        }
    }
}
