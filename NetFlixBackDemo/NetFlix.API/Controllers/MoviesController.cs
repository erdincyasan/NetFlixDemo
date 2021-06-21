using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstract;
using Netflix.Entities;
using System;
using System.Collections.Generic;

namespace NetFlix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public List<Movie> GetMovies([FromServices] IMovieService _movieService)
        {
            return _movieService.GetAllMovie();
        }

        [HttpGet("id")]
        public Movie GetMovieByID([FromServices] IMovieService _movieService, Guid id)
        {
            return _movieService.GetMovieByID(id);
        }

        [HttpPost]
        public Movie AddMovie([FromServices] IMovieService _movieService, [FromServices] IMovieCategoryService _movieCategoryService, [FromBody] Movie m)
        {

            //  _movieCategoryService.AddList(m.MovieCategories);
            return _movieService.AddMovie(m);
        }
        [HttpPut]
        public Movie UpdateMovie([FromServices] IMovieService _movieService, [FromServices] IMovieCategoryService _movieCategoryService, [FromBody] Movie m)
        {
            _movieCategoryService.DeleteMovieCategoriesByMovieID(m.MovieID);
            foreach (var item in m.MovieCategories)
            {
                item.MovieID = m.MovieID;
            }
            _movieCategoryService.AddList(m.MovieCategories);

            
            return _movieService.UpdateMovie(m);
        }
        [HttpDelete("{id}")]
        public void DeleteMovie([FromServices] IMovieService _movieService, [FromServices] IMovieCategoryService _movieCategoryService, Guid id)
        {
            Movie WillDeleteMovie = _movieService.GetMovieByID(id);
            var file = WillDeleteMovie.MoviePhoto;
            // var files = Directory.GetFiles(Path.Combine("Resources", "Images"), willDeleteFile);
            _movieCategoryService.DeleteMovieCategoriesByMovieID(id);
            _movieService.DeleteMovie(id);



            System.IO.File.Delete(file);


        }
    }
}
