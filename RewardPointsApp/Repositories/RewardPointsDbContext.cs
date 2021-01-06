using Microsoft.EntityFrameworkCore;
using RewardPointsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Repositories
{
    public class RewardPointsDbContext : DbContext
    {
        public RewardPointsDbContext(DbContextOptions<RewardPointsDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
           .HasOne(p => p.Customer)
           .WithMany(b => b.Invoices)
           .HasForeignKey(p => p.CustomerGuid);
        }

    }
}
