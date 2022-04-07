using Microsoft.EntityFrameworkCore;

namespace BloogingWebSite.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
    }
}