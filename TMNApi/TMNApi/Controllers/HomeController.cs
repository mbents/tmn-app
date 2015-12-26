using System.Web.Mvc;

namespace TMNApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }

    }
}
