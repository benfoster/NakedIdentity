using System.Security.Claims;
using System.Web.Mvc;

namespace NakedIdentity.Mvc.Controllers
{
    public abstract class AppController : Controller
    {       
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(base.User as ClaimsPrincipal);
            }
        }
    }
}