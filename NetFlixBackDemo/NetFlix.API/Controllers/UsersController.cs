using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstract;
using Netflix.Entities;
using System;

namespace NetFlix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers([FromServices] IUserService _userService)
        {

            return Ok(_userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public User GetUserByID([FromServices] IUserService _userService, Guid id)
        {
            return _userService.GetUserByID(id);
        }

        [HttpDelete]

        public void DeleteUser([FromServices] IUserService _userService, Guid id)
        {
            _userService.DeleteUser(id);
        }
        [HttpPost]
        public User AddUser([FromServices] IUserService _userService, [FromBody] User u)
        {

            u.UserID = Guid.NewGuid();
            return _userService.AddUser(u);
        }

        [HttpPut]
        public User UpdateUser([FromServices] IUserService _userService, [FromBody] User u)
        {
            return _userService.UpdateUser(u);
        }

    }
}