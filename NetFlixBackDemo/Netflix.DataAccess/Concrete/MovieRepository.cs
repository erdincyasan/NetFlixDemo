using Netflix.DataAccess.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netflix.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly NetflixDbContext dbContext;
        public MovieRepository(NetflixDbContext nf)
        {
            dbContext = nf;
        }
        public Movie AddMovie(Movie movie)
        {

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return movie;

        }

        public void DeleteMovieByID(Guid id)
        {

            Movie m = dbContext.Movies.Find(id);
            dbContext.Movies.Remove(m);
            dbContext.SaveChanges();

        }

        public List<Movie> GetAllMovies()
        {
            return dbContext.Movies.ToList();

        }

        public Movie GetMovieByID(Guid id)
        {

            Movie m = dbContext.Movies.Find(id);

            return m;

        }

        public Movie UpdateMovie(Movie movie)
        {
            Movie updateThis = dbContext.Movies.FirstOrDefault(x => x.MovieID == movie.MovieID);
            if (updateThis != null)
            {
                updateThis.UpdatedAt = movie.UpdatedAt;
                updateThis.MovieName = movie.MovieName;
                updateThis.MovieStar = movie.MovieStar;
                updateThis.MovieWatched = movie.MovieWatched;
                updateThis.MoviePhoto = movie.MoviePhoto;
            }

            dbContext.SaveChanges();

            return updateThis;

        }
    }
}
