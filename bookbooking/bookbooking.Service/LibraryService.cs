using bookbooking.Common.ViewModels.Library;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bookbooking.Service
{
    public class LibraryService
    {
        private IRepository<Book> bookRepository;
        private IRepository<Category> categoryRepository;
        public LibraryService(IRepository<Book> _bookRepository, IRepository<Category> _categoryRepository)
        {
            bookRepository = _bookRepository;
            categoryRepository = _categoryRepository;
        }
        public BookView BookList()
        {
            BookView bookView = new BookView();
            List<Category> category = new List<Category>();
            category = categoryRepository.GetAll().ToList();
            bookView.Books = bookRepository.GetAll().ToList();

            return bookView;
        }
        public void AddBook(BookView model)
        {
            bookRepository.Add(model.Book);
        }
        public void UpdateBook(BookView model)
        {
            bookRepository.Update(model.Book);
        }
        public void RemoveBook(BookView model)
        {
            bookRepository.Remove(model.Book);
        }
    }
}
