using Application.DTOs.UserDTOs.LoginUser;
using Application.DTOs.UserDTOs.RegisterUser;
using Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepo;

        public UserController(IUser userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpPost("loginUser")]
        public async Task<ActionResult<LoginUserResponse>> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var result = await userRepo.LoginUserAsync(loginUserDTO);
            return Ok(result);
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var result = await userRepo.RegisterUserAsync(registerUserDTO);
            return Ok(result);
        }
    }
}
