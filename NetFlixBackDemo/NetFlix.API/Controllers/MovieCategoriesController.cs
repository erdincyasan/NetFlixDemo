using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstract;
using Netflix.Entities;
using System.Collections.Generic;

namespace NetFlix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class MovieCategoriesController : ControllerBase
    {
        private readonly IMovieCategoryService _movieCategoryService;
        public MovieCategoriesController(IMovieCategoryService m)
        {
            _movieCategoryService = m;
        }
        [HttpGet]
        public List<MovieCategory> GetAll()
        {
            return _movieCategoryService.GetAll();
        }
    }
}
