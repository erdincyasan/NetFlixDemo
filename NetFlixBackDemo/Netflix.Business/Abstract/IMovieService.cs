using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace Netflix.Business.Abstract
{
    public interface IMovieService
    {
        List<Movie> GetAllMovie();
        Movie GetMovieByID(Guid id);
        Movie AddMovie(Movie m);
        Movie UpdateMovie(Movie m);
        void DeleteMovie(Guid m);
    }
}
