using Microsoft.Owin.Security;
using NakedIdentity.Mvc.ViewModels;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace NakedIdentity.Mvc.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Don't do this in production!
            if (model.Email == "admin@admin.com" && model.Password == "password")
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, "Ben"),
                        new Claim(ClaimTypes.Email, "a@b.com"),
                        new Claim(ClaimTypes.Country, "England")
                    },    
                    Startup.AuthenticationType);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut(Startup.AuthenticationType);
            return RedirectToAction("index", "home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
	}
}