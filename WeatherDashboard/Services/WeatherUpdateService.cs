using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using WeatherDashboard.Hubs;
using WeatherDashboard.Models;

namespace WeatherDashboard.Services
{
    public class WeatherUpdateService : BackgroundService
    {
        private readonly IHubContext<WeatherHub> _hubContext;
        private readonly HttpClient _httpClient;
        private readonly WeatherService _weatherService;
        bool aa {  get; set; }

        public WeatherUpdateService(IHubContext<WeatherHub> hubContext, 
            IHttpClientFactory httpClientFactory,
            WeatherService weatherService) 
        {
            _hubContext = hubContext;
            _httpClient = httpClientFactory.CreateClient();
            _weatherService = weatherService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            while (!stoppingToken.IsCancellationRequested)
            {
                aa = aa == true ? false : true;
                var cityName = aa ? "Taipei" : "Yunlin"; 
                var weatherData = await _weatherService.GetWeatherAsync(cityName);

                if (weatherData != null)
                {
                    double temperature = weatherData["main"]["temp"].Value<double>();
                    string description = weatherData["weather"][0]["description"].Value<string>();
                    int humidity = weatherData["main"]["humidity"].Value<int>();
                    double windSpeed = weatherData["wind"]["speed"].Value<double>();

                    var result = new
                    {
                        cityName = aa ? "臺北" : "雲林",
                        temperature = temperature,
                        description = description,
                        humidity = humidity,
                        windSpeed = windSpeed
                    };
                    await _hubContext.Clients.All.SendAsync("ReceiveWeatherUpdate", result);
                }

                try
                {
                    await Task.Delay(5000, stoppingToken); // 等待 10 秒
                }
                catch (TaskCanceledException)
                {
                    // 在取消時結束
                    break;
                }
            }
        }
    }
}
