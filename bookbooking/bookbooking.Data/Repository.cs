﻿using bookbooking.Entity;
using bookbooking.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace bookbooking.Data
{
    public interface IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}