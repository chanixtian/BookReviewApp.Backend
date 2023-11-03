using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Backend.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        public UserController(IUserService _service)
        {
            service = _service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm] UserCreateDto dto)
        {
            try
            {
                var user = await service.Register(dto);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto dto)
        {
            try
            {
                var user = await service.Login(dto);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await service.GetByUserId(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getall-user")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var user = await service.GetAlUser();

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("profile-details/{id}")]
        public async Task<IActionResult> UpdateProfileDetails([FromRoute] int id, [FromForm] UserUpdateProfileDetailsDto dto)
        {
            try
            {
                var user = await service.UpdateProfileDetails(id, dto);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> Activation(int id)
        {
            try
            {
                var user = await service.UserActivation(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("deactivation/{id}")]
        public async Task<IActionResult> Deactivation(int id)
        {
            try
            {
                var user = await service.UserActivation(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("validation/{id}")]
        public async Task<IActionResult> Validation(int id)
        {
            try
            {
                var user = await service.UserValidation(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await service.Delete(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
