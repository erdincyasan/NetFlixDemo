using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.DataAccess.Abstract
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieByID(Guid id);
        Movie AddMovie(Movie movie);
        Movie UpdateMovie(Movie movie);
        void DeleteMovieByID(Guid id);
    }
}
