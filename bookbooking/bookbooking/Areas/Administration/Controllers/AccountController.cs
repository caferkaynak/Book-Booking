using System.Threading.Tasks;
using bookbooking.Common.ViewModels.User;
using bookbooking.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using bookbooking.Service;
using bookbooking.Common.ViewModels;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AccountController : Controller
    {
        private IUserService userService;
        ServiceResult serviceResult = new ServiceResult();
        public AccountController(SignInManager<User> _singInManageR, UserManager<User> _userManager, IPasswordHasher<User> _passwordHasher,
            IPasswordValidator<User> _passwordValidator, IUserService _userService,RoleManager<IdentityRole> roleManager)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View(userService.User(User.Identity.Name));
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return View();
            }
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserView model)
        {
            if (ModelState.IsValid)
            {
                serviceResult = await userService.Login(model);
                if (serviceResult.Sonuc == true)
                    return RedirectToRoute("default", new { controller = "Home", action = "Index" });
            }
            return View();
        }
        public IActionResult LogOut()
        {
            userService.LogOut();
            return RedirectToRoute("default" ,new { controller = "Home", action = "Index" });
        }
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SingUp(UserView model)
        {
            if (ModelState.IsValid)
            {
                serviceResult = await userService.AddUser(model);
                if (serviceResult.Sonuc == true)
                    return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}