using System;
using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;

namespace WebApplication.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PcrTest> PcrTests { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity Framework Fluent API
            modelBuilder.Entity<PcrTest>().Property(x => x.Result).HasConversion<string>();

            modelBuilder.Entity<PcrTest>().HasOne(x => x.PerformerPerson).WithMany(x => x.PerformedPcrTests)
                .HasForeignKey(x => x.PerformerPersonId)
                .IsRequired(false);

            // modelBuilder.Entity<Observation>().Property(x => x.DateTime).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Observation>().Property(x => x.DateTime).HasDefaultValueSql("date()");

            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    Id = new Guid("d5a14f59-90ea-48a7-b781-6971e505d250"),
                    FirstName = "Ludwig",
                    LastName = "Lebrun"
                },
                new Person()
                {
                    Id = new Guid("e52b7f76-c61e-4f24-8f44-edb381e3df50"),
                    FirstName = "Hicham",
                    LastName = "Erradi"
                }
            );
        }
    }
}