using System.Collections.Generic;
using System.Linq;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService categoryService;
        ILibraryService libraryService;
        public HomeController(ICategoryService _categoryService, ILibraryService _libraryService)
        {
            categoryService = _categoryService;
            libraryService = _libraryService;
        }
        public IActionResult Index()
        {
            ViewBag.Category = new List<Category>();
            ViewBag.Category = categoryService.CategoryList().Categories.ToList();  
            return View(libraryService.BookList());
        }
    }
}