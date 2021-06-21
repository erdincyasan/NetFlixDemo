using Netflix.Business.Abstract;
using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Concrete
{
    public class MovieCategoryManager : IMovieCategoryService
    {
        private readonly IMovieCategoryRepository _movieCategoryRepository;
        public MovieCategoryManager(IMovieCategoryRepository movieCategoryRepository)
        {
            _movieCategoryRepository = movieCategoryRepository;
        }


        public void AddList(List<MovieCategory> m)
        {
            foreach (var item in m)
            {
                _movieCategoryRepository.Add(item);
            }
        }

        public void Delete(List<MovieCategory> m)
        {
            foreach (var item in m)
            {
                _movieCategoryRepository.Delete(item);
            }
        }

        public void DeleteMovieCategoriesByMovieID(Guid movieID)
        {
            _movieCategoryRepository.DeleteMovieCategoriesByMovieID(movieID);
        }

        public List<MovieCategory> GetAll()
        {
            return _movieCategoryRepository.GetAll();
        }

    }
}
