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
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<WatchTicker> Watchlist { get; set; }

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

            modelBuilder.Entity<Ticker>(builder =>
            {
                builder.ToTable("tickers");
                builder.HasKey(e => e.TickerId);
                builder.Property(e => e.TickerId).ValueGeneratedOnAdd();
                builder.Property(e => e.Name).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<WatchTicker>(builder =>
            {
                builder.ToTable("watchlist");
                builder.HasKey(e => e.WatchId);
                builder.Property(e => e.WatchId).IsRequired().ValueGeneratedOnAdd();
                builder.Property(e => e.UserId).IsRequired();
                builder.Property(e => e.TickerName).IsRequired().HasMaxLength(10);
                builder.HasOne(e => e.User)
                       .WithMany(e => e.Watchlist)
                       .HasForeignKey(e => e.UserId);
            });

            SeedData(modelBuilder);
        }

        private static readonly string[] _tickers = new string[]
        {
            "AAPL", "MSFT", "GOOG", "GOOGL", "AMZN", "FB", "TSLA", "TSM", "NVDA", "JPM", "V", "BABA", "IDXX", "JNJ",
            "UNH", "WMT", "BAC", "HD", "ADI", "MA", "PG", "ASML", "DIS", "ADBE", "NFLX", "CRM", "PYPL", "NTES", "ORCL",
            "XOM", "NKE", "CMCSA", "NVO", "PFE", "TMO", "TM", "KO", "CSCO", "LLY", "ABT", "DHR", "ACN", "PEP", "VZ", "CVX",
            "COST", "AVGO", "MRK", "WFC", "INTC", "SE", "ABBV", "AZN", "NVS", "TXN", "MS", "T", "MCD", "SHOP", "UPS", "SAP",
            "MDT", "NEE", "LIN", "INTU", "LOW", "SCHW", "UNP", "RY", "HON", "PM", "CHTR", "QCOM", "AXP", "TMUS", "AMD", "HDB",
            "BHP", "C", "GS", "SONY", "BLK", "UL", "RTX", "BBL", "NOW", "SBUX", "TTE", "TD", "MRNA", "JD", "AMT", "BMY", "ILMN",
            "PDD", "TGT", "BA", "SNY", "AMAT"
        };

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker>().HasData(
                _tickers.Select((t, index) => new Ticker
                    {
                        TickerId = -index-1,
                        Name = t
                    }).ToArray()
            );
        }
    }
}
