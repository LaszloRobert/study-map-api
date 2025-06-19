using StudyMapAPI.Data;
using StudyMapAPI.DTOs;
using StudyMapAPI.Repository;

namespace StudyMapAPI.Services
{
    public class CountyService
    {
        private readonly CountyRepository _countyRepository;

        public CountyService(CountyRepository countyRepository)
        {
            _countyRepository = countyRepository;
        }

        public async Task<List<string>> GetUnlockedCountiesAsync(int userId)
        {
            return await _countyRepository.GetUnlockedCountiesAsync(userId);
        }

        public async Task AddAsync(UserCountyDTO userCountyDto, int remainedCoins)
        {
            var userCounty = new UserCounty
            {
                UserId = userCountyDto.UserId,
                County = userCountyDto.County,
            };
            await _countyRepository.AddAsync(userCounty, remainedCoins);
        }
    }
}
