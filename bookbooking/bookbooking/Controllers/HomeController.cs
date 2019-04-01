using System.Linq;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index(int? id) // düzeltilecek base controller oluşturulacak
        {
            //TempData["Category"] = categoryService.CategoryList().Categories.ToList();
            //TempData["Author"] = libraryService.BookList().Authors.ToList();
            //BookView bookView = new BookView();
            //if (User.Identity.IsAuthenticated==true)
            //TempData["UserPhone"] = userService.User(User.Identity.Name).Phone;
            //TempData["UserName"] = userService.User(User.Identity.Name).Username;
            //TempData["UserEmail"] = userService.User(User.Identity.Name).Email;
            doldur();
            BookView bookView = new BookView();
            if (id == null)
            {
                bookView = libraryService.BookList();
                return View(bookView);
            }
            else
            {
                bookView = libraryService.BookList();
                bookView.Books = libraryService.BookList().Books = libraryService.BookList().Books.Where(w => w.CategoryId == id).ToList();
                return View(bookView);
            }

        }
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }
            return View();
        }
    }
}