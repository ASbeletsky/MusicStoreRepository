using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.WebUI.Models.Account
{
    public class UserInfoViewModel
    {
        public UserInfoViewModel() 
        {
            this.Phones = new List<string>();
            this.Addresses = new List<AddressViewModel>();
        }

        [Required]
        [Display(Name = "Имя")]
        [StringLength(10, ErrorMessage = "Имя должно содержать не больше 10 символов")]
        public string Name { get; set; }
        [Display(Name = "Электронная почта")]
        public string Email { get; set;}
        public List<string> Phones { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
    }

     public class AddressViewModel     
     {
         public AddressViewModel()
         {
             this.City = this.Street = this.House = string.Empty;
             
         }
         [Required]
         [Display(Name = "Город")]   
         public string City { get; set; }
         [Required]
         [Display(Name = "Улица")]
         public string Street { get; set; }
         [Required]
         [Display(Name = "Дом")]
         public string House { get; set; }
         [Display(Name = "Кв.")]
         public int? Apartment { get; set; }
     }
}