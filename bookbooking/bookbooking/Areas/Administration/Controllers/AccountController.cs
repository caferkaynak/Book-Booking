using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookbooking.Common.ViewModels;
using bookbooking.Data;
using bookbooking.Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AccountController : Controller
    {
        private IRepository<User> repository;
        private SignInManager<User> singInManager;
        private UserManager<User> userManager;
        public AccountController(IRepository<User> _repository, SignInManager<User> _singInManageR, UserManager<User> _userManager)
        {
            repository = _repository;
            singInManager = _singInManageR;
            userManager = _userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserListView model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user!=null)
                {
                    var result = await singInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}