using Microsoft.AspNetCore.Mvc;
using StudyMapAPI.DTOs;
using StudyMapAPI.Services;

namespace StudyMapAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountyController : ControllerBase
    {
        private readonly CountyService _countyService;
        public CountyController(CountyService countyService)
        {
            _countyService = countyService;
        }
        [HttpGet("getUnlockedCounties")]
        public async Task<IActionResult> GetUnlockedCounties(int userId)
        {
            var result = await _countyService.GetUnlockedCountiesAsync(userId);
            return Ok(result);
        }

        [HttpPost("unlockCounty")]
        public async Task<IActionResult> Add([FromBody] UserCountyDTO userCountyDto, int remainedCoins)
        {
            await _countyService.AddAsync(userCountyDto, remainedCoins);
            return Ok();
        }
    }
}
