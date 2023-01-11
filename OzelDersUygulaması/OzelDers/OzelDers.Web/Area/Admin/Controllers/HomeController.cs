using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Data.Config;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Models;

namespace OzelDers.Web.Area.Admin.Controllers;

public class HomeController : Controller
{
    [Area("Admin")]

    public IActionResult Index()
    {
        return View();
    }
}
