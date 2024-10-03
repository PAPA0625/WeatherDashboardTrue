using Newtonsoft.Json.Linq;

namespace WeatherDashboard.Models.ViewModels
{
    public class WeatherViewModel
    {
        public string CityName { get; set; }
        public JObject WeatherData { get; set; }
    }
}
