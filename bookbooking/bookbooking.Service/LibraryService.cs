using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using bookbooking.Service.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface ILibraryService
    { 
        BookView BookList();
        BookView BookList(string username);
        BookView UpdateBookList(int id);
        Task<ServiceResult> AddBook(BookView model, IFormFile file);
        Task<ServiceResult> UpdateBook(BookView model, IFormFile file);
        void AddAuthor(BookView model);
        void UpdateAuthor(BookView model);
        void RemoveAuthor(BookView model);
        void RemoveBook(int id);
    }
    public class LibraryService : ILibraryService
    {
        private IRepository<Book> bookRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Author> authorRepository;
        private IRepository<Card> cardRepository;
        ServiceResult serviceResult = new ServiceResult();
        BookView bookView = new BookView();
        public LibraryService(IRepository<Book> _bookRepository, 
            IRepository<Category> _categoryRepository, 
            IRepository<Author> _authorRepository,
            IRepository<Card> _cardRepository)
        {
            bookRepository = _bookRepository;
            categoryRepository = _categoryRepository;
            authorRepository = _authorRepository;
            cardRepository = _cardRepository;
        }
        public BookView BookList()
        {
            bookView.Books = bookRepository.GetAll().Include(i => i.Category).Include(i => i.Author).ToList();
            bookView.Categories = categoryRepository.GetAll().ToList();
            bookView.Authors = authorRepository.GetAll().ToList();
            return bookView;
        }
        public BookView BookList(string username)
        {
            bookView.Cards = cardRepository.GetAll().Include(i => i.Book).Include(i => i.User).Where(w => w.User.UserName == username).ToList();
            bookView.Books = bookRepository.GetAll().Include(i => i.Category).Include(i => i.Author).ToList();
            bookView.Categories = categoryRepository.GetAll().ToList();
            bookView.Authors = authorRepository.GetAll().ToList();
            return bookView;
        }
        public BookView UpdateBookList(int id)
        {
            bookView.Book = bookRepository.GetAll().Where(w => w.Id == id).FirstOrDefault();
            bookView.Books = bookRepository.GetAll().Include(i => i.Category).Include(i => i.Author).ToList();
            bookView.Categories = categoryRepository.GetAll().ToList();
            bookView.Authors = authorRepository.GetAll().ToList();
            return bookView;
        }
        public async Task<ServiceResult> AddBook(BookView model, IFormFile file)
        {
            if (file != null)
            {
                CurrentDirectoryHelpers.SetCurrentDirectory();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    model.Book.ImageName = file.FileName;
                    serviceResult.Sonuc = true;
                }
            }
            bookRepository.Add(model.Book);
            return serviceResult;
        }
        public async Task<ServiceResult> UpdateBook(BookView model, IFormFile file)
        {
            if (file != null)
            {
                CurrentDirectoryHelpers.SetCurrentDirectory();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    model.Book.ImageName = file.FileName;
                    serviceResult.Sonuc = true;
                }
            }
            serviceResult.Sonuc = true;
            bookRepository.Update(model.Book);
            return serviceResult;
        }
        public void RemoveBook(int id)
        {
            bookRepository.Remove(bookRepository.GetAll().Where(w => w.Id == id).FirstOrDefault());
        }
        public void AddAuthor(BookView model)
        {
            authorRepository.Add(model.Author);
        }
        public void UpdateAuthor(BookView model)
        {
            authorRepository.Update(model.Author);
        }
        public void RemoveAuthor(BookView model)
        {
            authorRepository.Remove(model.Author);
        }
    }
}
