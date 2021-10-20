using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;

namespace WebApplication.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PcrTest> PcrTests { get; set; }
    }
}