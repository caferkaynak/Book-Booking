using bookbooking.Common.ViewModels.Category;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace bookbooking.Service
{
    public interface ICategoryService
    {
        CategoryView CategoryList();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(Category category);
    }
    public class CategoryService : ICategoryService
    {
        public readonly IRepository<Category> categoryRepository;
        public CategoryService(IRepository<Category> _repository)
        {
            categoryRepository = _repository;
        }
        public CategoryView CategoryList()
        {
            CategoryView categoryView = new CategoryView();
            categoryView.Categories = categoryRepository.GetAll().ToList();
            return categoryView;
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
