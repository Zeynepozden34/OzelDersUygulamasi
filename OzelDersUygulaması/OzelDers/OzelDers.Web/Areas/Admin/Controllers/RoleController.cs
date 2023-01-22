using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.Web.Areas.Admin.Models.Dtos;

namespace OzelDers.Web.Areas.Admin.Controllers
{
  [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<RoleDto> roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            ViewBag.SelectedMenu = "Role";
            ViewBag.Title = "Roller";
            return View(roles);
        }
    }
}
