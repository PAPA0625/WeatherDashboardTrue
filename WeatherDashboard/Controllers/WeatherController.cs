using Microsoft.AspNetCore.Mvc;
using WeatherDashboard.Services;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WeatherDashboard.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;
        private readonly CountryService _countryService;
        private readonly CityService _cityService;

        public WeatherController(WeatherService weatherService,
            CountryService countryService,
            CityService cityService)
        {
            _weatherService = weatherService;
            _countryService = countryService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var countries = _countryService.GetAllCuuntry();
            ViewBag.Countries = countries;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = $"歡迎{User.Identity.Name}!";
            } 
            return View();
        }

        [HttpGet]
        public JsonResult GetCities(string countryCode)
        {
            var cities = _cityService.GetSelectCountrysCity(countryCode);
            return Json(cities);
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string countryCode, int cityId)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                return Json(new { success = false, message = "請選擇國家。" });
            }

            if (cityId == 0)
            {
                return Json(new { success = false, message = "請選擇城市。" });
            }

            var city = _cityService.GetCityById(cityId);
            if (city == null || city.CountryCode != countryCode)
            {
                return Json(new { success = false, message = "所選擇的城市無效。" });
            }

            var weatherData = await _weatherService.GetWeatherAsync(city.CityNameEn);
            if (weatherData == null)
            {
                return Json(new { success = false, message = "查閱天氣狀況失敗。" });
            }

            double temperature = weatherData["main"]["temp"].Value<double>();
            string description = weatherData["weather"][0]["description"].Value<string>();
            int humidity = weatherData["main"]["humidity"].Value<int>();
            double windSpeed = weatherData["wind"]["speed"].Value<double>();
            
            var result = new
            {
                success = true,
                cityName = city.CityNameZhTw,
                temperature = temperature,
                description = description,
                humidity = humidity,
                windSpeed = windSpeed
            };

            return Json(result);
        }
    }
}
