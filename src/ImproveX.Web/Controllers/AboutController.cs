using System.Web.Mvc;

namespace ImproveX.Web.Controllers
{
    public class AboutController : ImproveXControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}