using Microsoft.EntityFrameworkCore;
using StudyMapAPI.Data;
using System;

namespace StudyMapAPI.Repository
{
    public class UserRepository
    {
        private readonly StudyMapDbContext _context;

        public UserRepository(StudyMapDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByGoogleIdAsync(string googleId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.GoogleId == googleId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateUserCoinsAsync(int userId, int coins)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.Coins = coins;
                await _context.SaveChangesAsync();
            }
        }
    }
}
    