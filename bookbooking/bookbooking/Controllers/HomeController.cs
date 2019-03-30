﻿using System.Collections.Generic;
using System.Linq;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService categoryService;
        IUserService userService;
        private ILibraryService libraryService;
        public HomeController(ICategoryService _categoryService, ILibraryService _libraryService, SignInManager<User> _singInManageR, UserManager<User> _userManager, IPasswordHasher<User> _passwordHasher,
            IPasswordValidator<User> _passwordValidator, RoleManager<IdentityRole> _roleManager,IUserService _userService)
        {
            categoryService = _categoryService;
            libraryService = _libraryService;
            userService = _userService;
        }
        public IActionResult Index()
        {
            ViewBag.Category = new List<Category>();
            ViewBag.Author = new List<Author>();
            ViewBag.Category = categoryService.CategoryList().Categories.ToList();
            ViewBag.Author = libraryService.BookList().Authors.ToList();
            if (User.Identity.IsAuthenticated==true)
            {
                ViewBag.User = userService.User(User.Identity.Name);
            }
            return View(libraryService.BookList());
        }
    }
}