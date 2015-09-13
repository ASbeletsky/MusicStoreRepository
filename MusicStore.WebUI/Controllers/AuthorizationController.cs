
using Microsoft.Owin.Security;
using MusicStore.WebUI.Models.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Controllers
{
    public class AuthorizationController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication;}
        }
        public UserManagerIntPK userManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManagerIntPK>(); }
        }

        public ViewResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                UserIntPK newUser = new UserIntPK()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.Name
                };
                IdentityResult result = await userManager.CreateAsync(newUser, model.Password);
                if(result.Succeeded)
                {
                    return Json(new { Url = Url.RouteUrl("Home") });
                }
                else
                {
                    foreach(string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
           
        }

        public ViewResult LogIn(string returnUrl)
        {
            LogInViewModel model = new LogInViewModel
            {
                ReturnUrl = returnUrl,
                LoginProviders = AuthenticationManager.GetExternalAuthenticationTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserIntPK user = await userManager.FindAsync(model.Email, model.Password);
            if(user == null)
            {
                ModelState.AddModelError("", "Не правильный адрес эл. почты или пароль.");
            }
            else
            {
                ClaimsIdentity claim = await userManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(claim);
            }
                return Json(new { Url = GetRedirectUrl(model.ReturnUrl) });

        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                returnUrl = Url.RouteUrl("Home");
            }
            return returnUrl;
        }

        public ActionResult LogOut(string returnUrl)
        {                       
            AuthenticationManager.SignOut();
            return RedirectToRoute("Home");
        }
        
    }
}
