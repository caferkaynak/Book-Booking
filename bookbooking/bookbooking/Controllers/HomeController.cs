using System.Linq;
using bookbooking.Common.ViewModels.CardV;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index(int? id)
        {
            StartTemp();
            BookView bookView = new BookView();
            CardView cardView = new CardView();
            cardView = cardService.CardList(User.Identity.Name);
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
            StartTemp();
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