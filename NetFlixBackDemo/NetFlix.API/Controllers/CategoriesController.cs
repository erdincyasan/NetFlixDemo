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
    public class CategoriesController : ControllerBase
    {

        [HttpGet]
        public List<Category> GetCategories([FromServices] ICategoryService _categoryService)
        {
            return _categoryService.GetAllCategory();
        }

        [HttpGet("{id}")]
        public Category GetCategoryByID([FromServices] ICategoryService _categoryService, Guid id)
        {
            return _categoryService.GetCategoryByID(id);
        }

        [HttpPost]
        public Category AddCategory([FromServices] ICategoryService _categoryService, [FromBody] Category c)

        {
            //  c.WhoCreate = _userService.GetUserByID(c.UserID);
            return _categoryService.AddCategory(c);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory([FromServices] ICategoryService _categoryService, [FromServices] IMovieCategoryService _movieCategoryService, [FromServices] IMovieService _movieServce, Guid id)
        {
            List<MovieCategory> movieCategories = _movieCategoryService.GetAll();
            foreach (var item in movieCategories)
            {
                if (item.CategoryID == id)
                {
                    _movieServce.DeleteMovie(item.MovieID);
                }
            }
            _categoryService.DeleteCategory(id);
        }

        [HttpPut]
        public Category UpdateCategory([FromServices] ICategoryService _categoryService, [FromBody] Category c)
        {
            return _categoryService.UpdateCategory(c);
        }
    }
}
