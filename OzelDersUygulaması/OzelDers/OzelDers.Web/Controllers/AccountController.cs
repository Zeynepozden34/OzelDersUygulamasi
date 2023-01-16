using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.Web.Models;

namespace OzelDers.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IStudentService _studentManager;
        private readonly ITeacherService _teacherManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signManager, IStudentService studentManager, ITeacherService teacherManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _studentManager = studentManager;
            _teacherManager = teacherManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
                    return View(loginDto);
                }
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız onaylanmamaış lütfen mailinize gelen onay linkini tıklayınız.", "Warning");
                    return View(loginDto);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(loginDto.ReturnUrl ?? "~/");
                }
                ModelState.AddModelError("", "Email adresi ya da parola hatalı!");
            }
            return View(loginDto);
        }
        public IActionResult Register()
        {
            RegisterDto registerDto = new RegisterDto();
            return View(registerDto);
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    EmailConfirmed = true
                };

                if (registerDto.SelectedUser != null)
                {
                    if (registerDto.SelectedUser == "ogretmen")
                    {
                        Teacher teacher=new Teacher()
                        {
                            FirstName = registerDto.FirstName,
                            LastName = registerDto.LastName,
                            Email = registerDto.Email,
                            UserId = user.Id,
                            Description = registerDto.Description,
                            Phone = registerDto.Phone,
                            Gender = registerDto.Gender,
                            Url = user.UserName,
                            ImageUrl = Jobs.UploadImage(registerDto.ImageFile),
                            Location = registerDto.Location
                        };
                        
                        await _teacherManager.CreateAsync(teacher);
                    
                    } else if (registerDto.SelectedUser == "ogrenci")
                    {
                        Student student = new Student() { 
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName,
                        Email = registerDto.Email,
                        UserId = user.Id,
                       
                        Description =registerDto.Description,
                        Phone = registerDto.Phone,
                        Gender =registerDto.Gender,
                        Url = user.UserName,
                        Location = registerDto.Location,
                       ImageUrl = Jobs.UploadImage(registerDto.ImageFile)                          
                        };
                        
                        await _studentManager.CreateAsync(student);
                    }
                }
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                 
                    await _userManager.AddToRoleAsync(user, "User");                  
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız başarıyla oluşturulmuştur. Giriş yapabilirsiniz.", "success");
                    return RedirectToAction("Login", "Account");
                }
            }
            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
            return View(registerDto);
        }
    }
}
