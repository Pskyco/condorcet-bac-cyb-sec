using medical_data.Entities;
using Microsoft.EntityFrameworkCore;

namespace medical_data.Persistence
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