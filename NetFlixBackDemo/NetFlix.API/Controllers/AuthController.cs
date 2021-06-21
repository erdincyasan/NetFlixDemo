using Microsoft.AspNetCore.Mvc;
using Netflix.Business.Abstract;
using Netflix.Business.Concrete;
using Netflix.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace NetFlix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(IJwtService jwtservice, IUserService userService)
        {
            _jwtService = jwtservice;
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult deneme()
        {

            return Ok("Deneme");
        }
        [HttpPost("[action]")]
        public IActionResult SignIn(AuthRequestModel u)
        {
            User log = _userService.CheckMailAndPassword(u.UserMail, u.UserPasswordHash);
            
            if (log != null)
            {
            var token=  _jwtService.GenerateJwt(log);
                
                return Created("",new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    User = log,
                    expire=token.ValidTo,
                    Success=true
                });
            }
            else
            {
                
                return BadRequest("Hatalı bilgiler");
            }

           
        }

        [HttpGet("[action]")]
        public IActionResult SignUp(User u)
        {
            _userService.AddUser(u);
            return Created("", u);

        }
    }
}
