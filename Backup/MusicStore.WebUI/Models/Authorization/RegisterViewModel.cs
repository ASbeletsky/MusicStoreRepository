using System.ComponentModel.DataAnnotations;

namespace MusicStore.WebUI.Models.Authorization
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Имя должно содержать не больше 10 символов")]
        [Display(Name="Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Эл. почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string PasswordConfirm { get; set; }
    }
}