using bookbooking.Common.ViewModels.Category;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using System.Linq;

namespace bookbooking.Service
{
    public interface ICategoryService
    {
        CategoryView CategoryList();
        void AddCategory(CategoryView category);
        void UpdateCategory(CategoryView category);
        void RemoveCategory(CategoryView category);
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
        public void AddCategory(CategoryView model)
        {
            categoryRepository.Add(model.Category);
        }
        public void UpdateCategory(CategoryView model)
        {
            categoryRepository.Update(model.Category);
        }
        public void RemoveCategory(CategoryView model)
        {
            categoryRepository.Remove(categoryRepository.GetAll().Where(w => w.Id == model.Category.Id).FirstOrDefault());
        }
    }
}
