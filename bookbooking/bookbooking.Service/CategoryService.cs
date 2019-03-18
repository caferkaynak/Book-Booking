using bookbooking.Data;
using bookbooking.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Service
{
    public interface ICategoryService
    {
    }
    public class CategoryService : ICategoryService
    {
        public readonly IRepository<Category> categoryRepository;
        public CategoryService(IRepository<Category> _repository)
        {
            categoryRepository = _repository;
        }
        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
                
        }
        public void RemoveCategory(Category category)
        {
            categoryRepository.Remove(category);
        }
    }
}
