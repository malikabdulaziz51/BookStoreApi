using BookStoreApi.Dto;
using BookStoreApi.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> signUp(UserDto user)
        {
            var result = await _userService.SignUp(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> login(LoginDto user)
        {
            var result = await _userService.Login(user);
            if(result == null)
            {
                return BadRequest("User Not Found or Wrong Password");
            }
            return Ok(result);
        }
    }
}
