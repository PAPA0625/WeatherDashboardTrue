using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Services
{
    public class CityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<City> GetSelectCountrysCity(string countryCode)
        {
            var cities = _context.Cities.Where(c => c.CountryCode == countryCode);
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Where(c => c.CityId == cityId).FirstOrDefault();
            return city;
        }
    }
}
