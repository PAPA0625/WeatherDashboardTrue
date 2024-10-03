using System.ComponentModel.DataAnnotations;

namespace WeatherDashboard.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "請輸入暱稱")]
        [Display(Name = "暱稱")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "請輸入電子信箱")]
        [EmailAddress(ErrorMessage = "電子信箱格式錯誤")]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
    }
}
