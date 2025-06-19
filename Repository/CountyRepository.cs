using Microsoft.EntityFrameworkCore;
using StudyMapAPI.Data;

namespace StudyMapAPI.Repository
{
    public class CountyRepository
    {
        private readonly StudyMapDbContext _context;

        public CountyRepository(StudyMapDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUnlockedCountiesAsync(int userId)
        {
            return await _context.UserCounties
                                 .Where(uc => uc.UserId == userId)
                                 .Select(uc => uc.County)
                                 .ToListAsync();
        }

        public async Task AddAsync(UserCounty userCounty, int remainedCoins)
        {
            _context.UserCounties.Add(userCounty);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userCounty.UserId);
            if (user != null)
            {
                // Update the user's coins
                user.Coins = remainedCoins;
            }
            await _context.SaveChangesAsync();
        }

    }
}
