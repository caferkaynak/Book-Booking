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
        IRepository<Author> authorRepository;
        ServiceResult serviceResult = new ServiceResult();
        public LibraryController(ILibraryService _libraryService, IRepository<Category> categoryRepository, IRepository
            <Book> _bookRepository, IRepository<Author> _authorRepository)
        {
            libraryService = _libraryService;
            bookRepository = _bookRepository;
            authorRepository = _authorRepository;
        }

        public IActionResult Index()
        {
            return View(libraryService.BookList());
        }
        public IActionResult AddBook()
        {
            return View(libraryService.BookList());
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookView model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file==null)
                {
                    ModelState.AddModelError("NullFile", "Dosya Seçilmedi");
                    return View(libraryService.BookList());
                }
                else
                { 
                serviceResult = await libraryService.AddBook(model, file);
                if (serviceResult.Sonuc == true)
                    ModelState.AddModelError("Succeeded", "Kitap Eklendi");
                return View(libraryService.BookList());
                }
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(libraryService.UpdateBookList(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookView model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                serviceResult = await libraryService.UpdateBook(model, file);
                return RedirectToAction("Index", "Library");
            }
            return View(libraryService.UpdateBookList(model.Book.Id));
        }
        public IActionResult RemoveBook(int id)
        {
            libraryService.RemoveBook(id);
            return RedirectToAction("Index", "Library");
        }
        public IActionResult AddAuthor()
        {

            return View(libraryService.BookList());

        }
        [HttpPost]
        public IActionResult AddAuthor(BookView model)
        {
            if (ModelState.IsValid)
            {
                libraryService.AddAuthor(model);
                return View(libraryService.BookList());
            }
            return View(libraryService.BookList());
        }
        public IActionResult UpdateAuthor()
        {
            return View(libraryService.BookList());
        }
        [HttpPost]
        public IActionResult UpdateAuthor(BookView model)
        {
            if (ModelState.IsValid)
            {
                libraryService.UpdateAuthor(model);
                return View(libraryService.BookList());
            }
            return View(libraryService.BookList());
        }
        [HttpPost]
        public IActionResult RemoveAuthor(BookView model)
        {
            if (ModelState.IsValid)
            {
                libraryService.RemoveAuthor(model);
                return RedirectToAction("UpdateAuthor", "Library");
            }
            return RedirectToAction("UpdateAuthor", "Library");
        }
    }
}