using Microsoft.EntityFrameworkCore;
using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("users");
                builder.HasKey(e => e.UserId);
                builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
                builder.Property(e => e.Password).IsRequired().HasMaxLength(100);
            });

        }
    }
}
