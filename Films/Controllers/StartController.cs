using System.Web.Mvc;

namespace Films.Server.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}