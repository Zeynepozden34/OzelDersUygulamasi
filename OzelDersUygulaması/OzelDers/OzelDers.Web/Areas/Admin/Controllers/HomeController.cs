using Microsoft.AspNetCore.Mvc;

namespace OzelDers.Web.Area.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
