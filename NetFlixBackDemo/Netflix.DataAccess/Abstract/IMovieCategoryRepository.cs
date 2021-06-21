using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.DataAccess.Abstract
{
    public interface IMovieCategoryRepository
    {
        void Add(MovieCategory m);
        void Delete(MovieCategory m);
        List<MovieCategory> GetAll();
        void DeleteMovieCategoriesByMovieID(Guid id);
    }
}
