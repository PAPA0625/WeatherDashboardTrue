using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Services
{
    public class CountryService
    {
        private readonly ApplicationDbContext _context;

        public CountryService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IQueryable<Country> GetAllCuuntry()
        {
            var countries = _context.Countries;
            return countries;
        }
    }
}
