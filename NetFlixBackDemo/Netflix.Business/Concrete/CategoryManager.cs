using Netflix.Business.Abstract;
using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category AddCategory(Category c)
        {

            //c.CategoryID = Guid.NewGuid();
            return _categoryRepository.AddCategory(c);

        }

        public void DeleteCategory(Guid CategoryId)
        {
            _categoryRepository.DeleteCategoryByID(CategoryId);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryByID(Guid CategoryID)
        {
            return _categoryRepository.GetCategoryByID(CategoryID);
        }

        public Category UpdateCategory(Category c)
        {
            return _categoryRepository.UpdateCategory(c);

        }
    }
}
