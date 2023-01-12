using Microsoft.AspNetCore.Mvc;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
