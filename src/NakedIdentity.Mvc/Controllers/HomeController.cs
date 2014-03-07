using System.Web.Mvc;

namespace NakedIdentity.Mvc.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}