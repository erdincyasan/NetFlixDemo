using Netflix.Business.Abstract;
using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieCategoryRepository _movieCategoryRepository;
        public MovieManager(IMovieRepository movieRepository, IMovieCategoryRepository movieCategoryRepository)
        {
            _movieRepository = movieRepository;
            _movieCategoryRepository = movieCategoryRepository;
        }
        public Movie AddMovie(Movie m)
        {
            m.MovieID = Guid.NewGuid();
            foreach (MovieCategory item in m.MovieCategories)
            {
                item.MovieID = m.MovieID;
            }
            foreach (var item in m.MovieCategories)
            {
                _movieCategoryRepository.Add(item);
            }
            {

            }
            return _movieRepository.AddMovie(m);
        }

        public void DeleteMovie(Guid m)
        {
            _movieRepository.DeleteMovieByID(m);
        }

        public List<Movie> GetAllMovie()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieByID(Guid id)
        {
            return _movieRepository.GetMovieByID(id);
        }

        public Movie UpdateMovie(Movie m)
        {
            if (m.UpdatedAt < DateTime.Now)
            {
                m.UpdatedAt = DateTime.Now;
            }

            return _movieRepository.UpdateMovie(m);

        }
    }
}
