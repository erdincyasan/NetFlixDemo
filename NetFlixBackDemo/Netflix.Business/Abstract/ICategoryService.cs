using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        Category GetCategoryByID(Guid CategoryID);
        Category UpdateCategory(Category c);
        Category AddCategory(Category c);
        void DeleteCategory(Guid CategoryId);
    }
}
