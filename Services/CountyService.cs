using StudyMapAPI.Data;
using StudyMapAPI.DTOs;
using StudyMapAPI.Repository;

namespace StudyMapAPI.Services
{
    public class CountyService
    {
        private readonly CountyRepository _countyRepository;
        private readonly UserRepository _userRepository;

        public CountyService(CountyRepository countyRepository, UserRepository userRepository)
        {
            _countyRepository = countyRepository;
            _userRepository = userRepository;
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

        public async Task SaveUserCoinsAsync(int userId, int coins)
        {
            await _userRepository.UpdateUserCoinsAsync(userId, coins);
        }
    }
}
