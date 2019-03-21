﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookbooking.Common.ViewModels.User;
using bookbooking.Data;
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
            IPasswordValidator<User> _passwordValidator, IUserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserView model)
        {
            if (ModelState.IsValid)
             serviceResult = await userService.Login(model);
            if (serviceResult.sonuc == true)
                return RedirectToAction("Index", "Account");
            return View();
        }
        public IActionResult LogOut()
        {
            userService.LogOut();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SingUp(UserView model)
        {     
            if (ModelState.IsValid)
           serviceResult = await userService.AddUser(model);
            if (serviceResult.sonuc == true)
                return RedirectToAction("Login", "Account");
            return View();
        }
    }
}