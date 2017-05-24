using System.Web.Mvc;

namespace Films.Server.Controllers
{
    public class FilmsController : BaseController
    {
        public ActionResult Index()
        {
            return View(_films.GetAll());
        }


    }
}