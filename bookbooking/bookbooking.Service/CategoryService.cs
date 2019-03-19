using bookbooking.Data;
using bookbooking.Data.Model;
using bookbooking.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ICollection<Category> CategoryList()
        {
            return categoryRepository.GetAll().ToList();
            
        }
        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(new Category
            {
                Id = category.Id,
                Name=category.Name 
            });

        }
        public void RemoveCategory(Category category)
        {
            categoryRepository.Remove(category);
        }
    }
}
