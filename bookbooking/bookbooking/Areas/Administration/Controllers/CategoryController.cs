using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService,IRepository<Category> _repository)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            return View(categoryService.CategoryList());
        }
    }
}