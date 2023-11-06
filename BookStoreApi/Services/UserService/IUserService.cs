using BookStoreApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Services.UserService
{
    public interface IUserService
    {
        public Task<ActionResult<User>>? SignUp(UserDto user);

        public Task<ActionResult<string>>? Login(LoginDto user);
    }
}
