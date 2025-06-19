using Microsoft.AspNetCore.Mvc;
using StudyMapAPI.DTOs;
using StudyMapAPI.Services;

namespace StudyMapAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var result = await _userService.LoginAsync(loginDto.Token);
            return Ok(result);
        }

        [HttpPost("loginLocal")]
        public async Task<IActionResult> LoginLocal([FromBody] LoginLocalDTO loginDto)
        {
            try
            {
                var user = await _userService.LoginLocalAsync(loginDto.Email, loginDto.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            try
            {
                var user = await _userService.RegisterAsync(registerDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
