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
        public List<Category> CategoryList()
        {
          return categoryRepository.GetAll();

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
