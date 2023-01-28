using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.Web.Areas.Admin.Models.Dtos;
using System;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITeacherService _teacherManager;
        private readonly IStudentService _StudentManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, ITeacherService teacherManager, IStudentService studentManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherManager = teacherManager;
            _StudentManager = studentManager;
        }

        public IActionResult Index()
        {
            List<UserDto> users = _userManager.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();
            ViewBag.SelectedMenu = "User";
            ViewBag.Title = "Kullanıcılar";
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            UserAddDto userAddDto = new UserAddDto
            {
                Roles = _roleManager.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList(),
                SelectedRoles = new List<string>()

            };
            ViewBag.Title = "Kullanıcı Oluştur";
            return View(userAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userAddDto.FirstName,
                    LastName = userAddDto.LastName,
                    UserName = userAddDto.UserName,
                    Email = userAddDto.Email,
                    EmailConfirmed = userAddDto.EmailConfirmed
                };
                foreach (var role in userAddDto.SelectedRoles)
                {
                    var userRole = await _roleManager.FindByNameAsync(role);

                    if (userRole.Name == "Teacher")
                    {
                        
                        var teacher = new Teacher
                        {
                            FirstName = userAddDto.FirstName,
                            LastName = userAddDto.LastName,
                            UserName = userAddDto.UserName,
                            Email = userAddDto.Email,
                            EmailConfirmed = userAddDto.EmailConfirmed,
                            

                        };
                        await _teacherManager.CreateAsync(teacher);

                    }
                    else if (userRole.Name == "Student")
                    {
                        var student = new Student
                        {
                            FirstName = userAddDto.FirstName,
                            LastName = userAddDto.LastName,
                            UserName = userAddDto.UserName,
                            Email = userAddDto.Email,
                            EmailConfirmed = userAddDto.EmailConfirmed,
                            

                        };
                        await _StudentManager.CreateAsync(student);
                    }
                }
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, userAddDto.SelectedRoles);

                    TempData["Message"] = Jobs.CreateMessage("Başarılı", $"{user.UserName} kullanıcısı başarıyla oluşturuldu.", "success");
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            userAddDto.Roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            userAddDto.SelectedRoles = userAddDto.SelectedRoles ?? new List<string>();
            return View(userAddDto);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            UserAddDto userUpdateDto = new UserAddDto
            {
                UserDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    UserName = user.UserName,
                    
                },
                SelectedRoles = await _userManager.GetRolesAsync(user),
                Roles = _roleManager.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList()
            };
            return View(userUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserAddDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userUpdateDto.Id);
                if (user == null) { return NotFound(); }
                user.FirstName = userUpdateDto.FirstName;
                user.LastName = userUpdateDto.LastName;
                user.UserName = userUpdateDto.UserName;
                user.Email = userUpdateDto.Email;
                user.EmailConfirmed = userUpdateDto.EmailConfirmed;
                user.UserName = userUpdateDto.UserName;
                

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) { return NotFound(); }
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.AddToRolesAsync(
                    user,
                    userUpdateDto.SelectedRoles.Except(userRoles).ToList<string>()
                    );
                await _userManager.RemoveFromRolesAsync(
                    user,
                    userRoles.Except(userUpdateDto.SelectedRoles).ToList<string>()
                    );
                TempData["Message"] = Jobs.CreateMessage("Başarılı", $"{user.UserName} kullanıcısı başarıyla güncellendi.", "success");
                return RedirectToAction("Index", "User");
            }
            userUpdateDto.Roles = _roleManager.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            userUpdateDto.SelectedRoles = userUpdateDto.SelectedRoles ?? new List<string>();
            return View(userUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);


            return RedirectToAction("Index");
        }
    }
}
