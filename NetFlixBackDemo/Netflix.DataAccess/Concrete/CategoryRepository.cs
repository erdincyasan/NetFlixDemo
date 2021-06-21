using Microsoft.EntityFrameworkCore;
using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netflix.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NetflixDbContext _context;
        public CategoryRepository(NetflixDbContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category c)
        {
            _context.Categories.Include(x => x.WhoCreate);

            _context.Categories.Add(c);
            _context.SaveChanges();
            return c;

        }

        public void DeleteCategoryByID(Guid id)
        {

            Category c = _context.Categories.Find(id);
            _context.Categories.Remove(c);
            _context.SaveChanges();


        }

        public List<Category> GetAllCategories()
        {

            return _context.Categories.ToList();

        }

        public Category GetCategoryByID(Guid id)
        {

            Category c = _context.Categories.Find(id);

            return c;

        }

        public Category UpdateCategory(Category c)
        {

            _context.Categories.Update(c);
            _context.SaveChanges();
            return c;

        }
    }
}
