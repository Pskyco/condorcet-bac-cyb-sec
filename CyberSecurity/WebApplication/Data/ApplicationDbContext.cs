using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Entities;

namespace WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Account> Accounts;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
                new Account() { Id = 1, Balance = 2489.50m, Number = "123456789" },
                new Account() { Id = 2, Balance = 65978.20m, Number = "987654321" },
                new Account() { Id = 3, Balance = 123256.10m, Number = "01020304" }
            );
            base.OnModelCreating(builder);
        }
    }
}