using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.Library;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using bookbooking.Service.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface ILibraryService
    {
        BookView BookList();
        BookView UpdateBookList(int id);
        Task<ServiceResult> AddBook(BookView model,IFormFile file);
        Task<ServiceResult> UpdateBook(BookView model, IFormFile file);
        void RemoveBook(int id);
    }

    public class LibraryService : ILibraryService
    {
        private IRepository<Book> bookRepository;
        private IRepository<Category> categoryRepository;
        ServiceResult serviceResult = new ServiceResult();
        BookView bookView = new BookView();
        public LibraryService(IRepository<Book> _bookRepository, IRepository<Category> _categoryRepository)
        {
            bookRepository = _bookRepository;
            categoryRepository = _categoryRepository;
        }
        public BookView BookList()
        {
            
            bookView.Books = bookRepository.GetAll().Include(i => i.Category).ToList();
            bookView.categories = categoryRepository.GetAll().ToList();
            return bookView;
        }
        public BookView UpdateBookList(int id)
        {
            bookView.Book = bookRepository.GetAll().Where(w => w.Id == id).FirstOrDefault();
            bookView.Books = bookRepository.GetAll().Include(i => i.Category).ToList();
            bookView.categories = categoryRepository.GetAll().ToList();
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
                    serviceResult.sonuc = true;
                }
            }
                bookRepository.Add(model.Book);
            return serviceResult;
        }
        public async Task<ServiceResult> UpdateBook(BookView model, IFormFile file)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                model.Book.ImageName = file.FileName;
                serviceResult.sonuc = true;
            }
            bookRepository.Update(model.Book);
            return serviceResult;
        }
        public void RemoveBook(int id)
        {
            bookRepository.Remove(bookRepository.GetAll().Where(w => w.Id == id).FirstOrDefault());
        }
    }
}
