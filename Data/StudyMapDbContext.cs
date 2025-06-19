using Microsoft.EntityFrameworkCore;
using System;

namespace StudyMapAPI.Data
{
    public class StudyMapDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserCounty> UserCounties { get; set; }

        public StudyMapDbContext(DbContextOptions<StudyMapDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.GoogleId).IsUnique();
        }
    }
}
