using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryByID(Guid id);
        Category UpdateCategory(Category c);
        Category AddCategory(Category c);

        void DeleteCategoryByID(Guid id);
    }
}
