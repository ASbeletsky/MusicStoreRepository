using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.WebUI.Models.Account;
using MusicStore.Domain.Entities;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;

namespace MusicStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IMusicInstrumentRepository repository { get; set; }        
        public AccountController(IMusicInstrumentRepository repo)
        {
            repository = repo;
        }
        public UserManagerIntPK userManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManagerIntPK>(); }
        }

        public async Task<ActionResult> EditUserInfo()
        {
            UserIntPK currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            UserInfoViewModel userInfoModel = new UserInfoViewModel()
            {
                Email = currentUser.Email,
                Name = currentUser.Name,
                Phones = repository.userPhones.Where(x => x.User_Id == currentUser.Id).Select(x => x.PhoneNumber).ToList(),
                Addresses = repository.Addresses.Where(x => x.User_Id == currentUser.Id).Select(addres => new AddressViewModel
                {
                    City = addres.City,
                    Street = addres.Street,
                    House = addres.House,
                    Apartment = addres.Apartment
                }).ToList()
            };

            if (userInfoModel.Phones.Count() == 0)
                userInfoModel.Phones.Add(string.Empty);
            if (userInfoModel.Addresses.Count() == 0)
                userInfoModel.Addresses.Add(new AddressViewModel());
            TempData["userInfoModel"] = userInfoModel;
            return View(userInfoModel);
        }   
 
        
    }
}
