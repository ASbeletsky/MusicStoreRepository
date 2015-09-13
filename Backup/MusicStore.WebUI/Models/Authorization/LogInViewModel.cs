using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace MusicStore.WebUI.Models.Authorization
{
    public class LogInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Эл. почта")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [HiddenInput]
        public string ReturnUrl { get; set; }
        public IEnumerable<AuthenticationDescription> LoginProviders { get; set; }
    }
}