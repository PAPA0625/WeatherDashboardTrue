using WeatherDashboard.Data;
using WeatherDashboard.Models;
using WeatherDashboard.Repositories;

namespace WeatherDashboard.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository _userRepository;

        public UserService(ApplicationDbContext context, 
            UserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public void NewRegister(User user)
        {
            if (user == null)
                return;

            _userRepository.Insert(user);
        }
    }
}
