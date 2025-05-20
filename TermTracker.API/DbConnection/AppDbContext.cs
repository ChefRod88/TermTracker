using Microsoft.EntityFrameworkCore;
using TermTracker.API.Models;

namespace TermTracker.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
    }
}
