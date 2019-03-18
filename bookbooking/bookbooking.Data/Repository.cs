using bookbooking.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bookbooking.Data
{
    public interface IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll();
        //IQueryable<Category> Categories { get; }
        //IQueryable<User> Users { get; }
        //IQueryable<Book> Books { get; }
        //IQueryable<Reservation> Reservations { get; }
        //IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        //IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        //IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        //T Get(Expression<Func<T, bool>> predicate);
        //T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        //Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        //T Find(object key);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly bookbookingContext context;
        private readonly DbSet<T> dbSet;
        public Repository(bookbookingContext _context)
        {
            context = _context;
        }
        //public IQueryable<User> Users => context.Users;
        //public IQueryable<Book> Books => context.Books;
        //public IQueryable<Reservation> Reservations => context.Reservations;
        //public IQueryable<Category> Categories => context.Categories;
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
