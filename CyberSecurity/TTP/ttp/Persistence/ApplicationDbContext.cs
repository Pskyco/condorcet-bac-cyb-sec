using Microsoft.EntityFrameworkCore;
using ttp.Entities;

namespace ttp.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantLink>().ToTable("ParticipantLink");
            base.OnModelCreating(modelBuilder);
        }
    }
}