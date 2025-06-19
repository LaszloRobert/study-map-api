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
    }
}
    