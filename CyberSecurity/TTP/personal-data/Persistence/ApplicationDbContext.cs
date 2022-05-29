using Microsoft.EntityFrameworkCore;
using personal_data.Entities;

namespace personal_data.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().ToTable("Participant");
            base.OnModelCreating(modelBuilder);
        }
    }
}