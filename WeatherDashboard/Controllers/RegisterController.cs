using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeatherDashboard.Models;
using WeatherDashboard.Models.ViewModels;
using WeatherDashboard.Services;

namespace WeatherDashboard.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController(UserService userService, 
            SignInManager<IdentityUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewUserRegister(string nickname, string email, string password)
        {
            if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "所有欄位都是必填的");
                return View(); // 返回視圖，並顯示錯誤
            }

            var user = new User
            {
                Username = nickname,
                Email = email,
                PasswordHash = password,
                CreatedAt = DateTime.UtcNow.AddHours(8)
            };

            _userService.NewRegister(user);

            // 註冊成功後重定向到其他頁面
            var identityUser = new IdentityUser { UserName = email, Email = email };
            await _signInManager.SignInAsync(identityUser, isPersistent: false);
            return RedirectToAction("Index", "Weather");
        }
    }
}
