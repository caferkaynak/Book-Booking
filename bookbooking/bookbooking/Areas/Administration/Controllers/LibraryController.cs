using System.Threading.Tasks;
using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class LibraryController : Controller
    {
        ILibraryService libraryService;
        IRepository<Book> bookRepository;
        ServiceResult serviceResult = new ServiceResult();
        public LibraryController(ILibraryService _libraryService, IRepository<Category> categoryRepository, IRepository
            <Book> _bookRepository)
        {
            libraryService = _libraryService;
            bookRepository = _bookRepository;
        }

        public IActionResult Index()
        {
            return View(libraryService.BookList());
        }
        public IActionResult Add()
        {
            return View(libraryService.BookList());
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookView model, IFormFile file)
        {
            serviceResult = await libraryService.AddBook(model, file);
            if (serviceResult.sonuc == true)
            {
                ModelState.AddModelError("Succeeded", "Succeeded");
            }
            return View(libraryService.BookList());
        }
        public IActionResult Update(int id)
        {  
            return View(libraryService.UpdateBookList(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookView model, IFormFile file)
        {
            serviceResult =await libraryService.UpdateBook(model, file);
            return RedirectToAction("Index", "Library");
        }
        public IActionResult Remove(int id)
        {
            libraryService.RemoveBook(id);
            return RedirectToAction("Index", "Library");
        }
    }
}