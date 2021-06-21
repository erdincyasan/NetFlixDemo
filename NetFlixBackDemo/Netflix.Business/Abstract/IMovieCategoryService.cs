using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Abstract
{
    public interface IMovieCategoryService
    {

        void Delete(List<MovieCategory> m);
        void AddList(List<MovieCategory> m);

        List<MovieCategory> GetAll();
        void DeleteMovieCategoriesByMovieID(Guid movieID);
    }
}
