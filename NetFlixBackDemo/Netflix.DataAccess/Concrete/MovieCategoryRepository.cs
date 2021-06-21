using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netflix.DataAccess.Concrete
{
    public class MovieCategoryRepository : IMovieCategoryRepository
    {
        private readonly NetflixDbContext _context;
        public MovieCategoryRepository(NetflixDbContext cnt)
        {
            _context = cnt;
        }

        public void Add(MovieCategory m)
        {
            _context.MovieCategories.Add(m);
        }

        public void Delete(MovieCategory m)
        {
            _context.MovieCategories.Remove(m);
        }

        public List<MovieCategory> GetAll()
        {
            return _context.MovieCategories.ToList();
        }

        public void DeleteMovieCategoriesByMovieID(Guid movieID)
        {
            _context.MovieCategories.RemoveRange(_context.MovieCategories.Where(I => I.MovieID == movieID));
            _context.SaveChanges();
        }


    }
}
