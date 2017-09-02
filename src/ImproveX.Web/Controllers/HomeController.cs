using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ImproveX.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ImproveXControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}