﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stocks.Server.Models;

namespace Stocks.Server.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20211029153438_datapoints table")]
    partial class datapointstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stocks.Server.Models.DTO.Ticker", b =>
                {
                    b.Property<int>("TickerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TickerId");

                    b.ToTable("tickers");

                    b.HasData(
                        new
                        {
                            TickerId = -1,
                            Name = "AAPL"
                        },
                        new
                        {
                            TickerId = -2,
                            Name = "MSFT"
                        },
                        new
                        {
                            TickerId = -3,
                            Name = "GOOG"
                        },
                        new
                        {
                            TickerId = -4,
                            Name = "GOOGL"
                        },
                        new
                        {
                            TickerId = -5,
                            Name = "AMZN"
                        },
                        new
                        {
                            TickerId = -6,
                            Name = "FB"
                        },
                        new
                        {
                            TickerId = -7,
                            Name = "TSLA"
                        },
                        new
                        {
                            TickerId = -8,
                            Name = "TSM"
                        },
                        new
                        {
                            TickerId = -9,
                            Name = "NVDA"
                        },
                        new
                        {
                            TickerId = -10,
                            Name = "JPM"
                        },
                        new
                        {
                            TickerId = -11,
                            Name = "V"
                        },
                        new
                        {
                            TickerId = -12,
                            Name = "BABA"
                        },
                        new
                        {
                            TickerId = -13,
                            Name = "IDXX"
                        },
                        new
                        {
                            TickerId = -14,
                            Name = "JNJ"
                        },
                        new
                        {
                            TickerId = -15,
                            Name = "UNH"
                        },
                        new
                        {
                            TickerId = -16,
                            Name = "WMT"
                        },
                        new
                        {
                            TickerId = -17,
                            Name = "BAC"
                        },
                        new
                        {
                            TickerId = -18,
                            Name = "HD"
                        },
                        new
                        {
                            TickerId = -19,
                            Name = "ADI"
                        },
                        new
                        {
                            TickerId = -20,
                            Name = "MA"
                        },
                        new
                        {
                            TickerId = -21,
                            Name = "PG"
                        },
                        new
                        {
                            TickerId = -22,
                            Name = "ASML"
                        },
                        new
                        {
                            TickerId = -23,
                            Name = "DIS"
                        },
                        new
                        {
                            TickerId = -24,
                            Name = "ADBE"
                        },
                        new
                        {
                            TickerId = -25,
                            Name = "NFLX"
                        },
                        new
                        {
                            TickerId = -26,
                            Name = "CRM"
                        },
                        new
                        {
                            TickerId = -27,
                            Name = "PYPL"
                        },
                        new
                        {
                            TickerId = -28,
                            Name = "NTES"
                        },
                        new
                        {
                            TickerId = -29,
                            Name = "ORCL"
                        },
                        new
                        {
                            TickerId = -30,
                            Name = "XOM"
                        },
                        new
                        {
                            TickerId = -31,
                            Name = "NKE"
                        },
                        new
                        {
                            TickerId = -32,
                            Name = "CMCSA"
                        },
                        new
                        {
                            TickerId = -33,
                            Name = "NVO"
                        },
                        new
                        {
                            TickerId = -34,
                            Name = "PFE"
                        },
                        new
                        {
                            TickerId = -35,
                            Name = "TMO"
                        },
                        new
                        {
                            TickerId = -36,
                            Name = "TM"
                        },
                        new
                        {
                            TickerId = -37,
                            Name = "KO"
                        },
                        new
                        {
                            TickerId = -38,
                            Name = "CSCO"
                        },
                        new
                        {
                            TickerId = -39,
                            Name = "LLY"
                        },
                        new
                        {
                            TickerId = -40,
                            Name = "ABT"
                        },
                        new
                        {
                            TickerId = -41,
                            Name = "DHR"
                        },
                        new
                        {
                            TickerId = -42,
                            Name = "ACN"
                        },
                        new
                        {
                            TickerId = -43,
                            Name = "PEP"
                        },
                        new
                        {
                            TickerId = -44,
                            Name = "VZ"
                        },
                        new
                        {
                            TickerId = -45,
                            Name = "CVX"
                        },
                        new
                        {
                            TickerId = -46,
                            Name = "COST"
                        },
                        new
                        {
                            TickerId = -47,
                            Name = "AVGO"
                        },
                        new
                        {
                            TickerId = -48,
                            Name = "MRK"
                        },
                        new
                        {
                            TickerId = -49,
                            Name = "WFC"
                        },
                        new
                        {
                            TickerId = -50,
                            Name = "INTC"
                        },
                        new
                        {
                            TickerId = -51,
                            Name = "SE"
                        },
                        new
                        {
                            TickerId = -52,
                            Name = "ABBV"
                        },
                        new
                        {
                            TickerId = -53,
                            Name = "AZN"
                        },
                        new
                        {
                            TickerId = -54,
                            Name = "NVS"
                        },
                        new
                        {
                            TickerId = -55,
                            Name = "TXN"
                        },
                        new
                        {
                            TickerId = -56,
                            Name = "MS"
                        },
                        new
                        {
                            TickerId = -57,
                            Name = "T"
                        },
                        new
                        {
                            TickerId = -58,
                            Name = "MCD"
                        },
                        new
                        {
                            TickerId = -59,
                            Name = "SHOP"
                        },
                        new
                        {
                            TickerId = -60,
                            Name = "UPS"
                        },
                        new
                        {
                            TickerId = -61,
                            Name = "SAP"
                        },
                        new
                        {
                            TickerId = -62,
                            Name = "MDT"
                        },
                        new
                        {
                            TickerId = -63,
                            Name = "NEE"
                        },
                        new
                        {
                            TickerId = -64,
                            Name = "LIN"
                        },
                        new
                        {
                            TickerId = -65,
                            Name = "INTU"
                        },
                        new
                        {
                            TickerId = -66,
                            Name = "LOW"
                        },
                        new
                        {
                            TickerId = -67,
                            Name = "SCHW"
                        },
                        new
                        {
                            TickerId = -68,
                            Name = "UNP"
                        },
                        new
                        {
                            TickerId = -69,
                            Name = "RY"
                        },
                        new
                        {
                            TickerId = -70,
                            Name = "HON"
                        },
                        new
                        {
                            TickerId = -71,
                            Name = "PM"
                        },
                        new
                        {
                            TickerId = -72,
                            Name = "CHTR"
                        },
                        new
                        {
                            TickerId = -73,
                            Name = "QCOM"
                        },
                        new
                        {
                            TickerId = -74,
                            Name = "AXP"
                        },
                        new
                        {
                            TickerId = -75,
                            Name = "TMUS"
                        },
                        new
                        {
                            TickerId = -76,
                            Name = "AMD"
                        },
                        new
                        {
                            TickerId = -77,
                            Name = "HDB"
                        },
                        new
                        {
                            TickerId = -78,
                            Name = "BHP"
                        },
                        new
                        {
                            TickerId = -79,
                            Name = "C"
                        },
                        new
                        {
                            TickerId = -80,
                            Name = "GS"
                        },
                        new
                        {
                            TickerId = -81,
                            Name = "SONY"
                        },
                        new
                        {
                            TickerId = -82,
                            Name = "BLK"
                        },
                        new
                        {
                            TickerId = -83,
                            Name = "UL"
                        },
                        new
                        {
                            TickerId = -84,
                            Name = "RTX"
                        },
                        new
                        {
                            TickerId = -85,
                            Name = "BBL"
                        },
                        new
                        {
                            TickerId = -86,
                            Name = "NOW"
                        },
                        new
                        {
                            TickerId = -87,
                            Name = "SBUX"
                        },
                        new
                        {
                            TickerId = -88,
                            Name = "TTE"
                        },
                        new
                        {
                            TickerId = -89,
                            Name = "TD"
                        },
                        new
                        {
                            TickerId = -90,
                            Name = "MRNA"
                        },
                        new
                        {
                            TickerId = -91,
                            Name = "JD"
                        },
                        new
                        {
                            TickerId = -92,
                            Name = "AMT"
                        },
                        new
                        {
                            TickerId = -93,
                            Name = "BMY"
                        },
                        new
                        {
                            TickerId = -94,
                            Name = "ILMN"
                        },
                        new
                        {
                            TickerId = -95,
                            Name = "PDD"
                        },
                        new
                        {
                            TickerId = -96,
                            Name = "TGT"
                        },
                        new
                        {
                            TickerId = -97,
                            Name = "BA"
                        },
                        new
                        {
                            TickerId = -98,
                            Name = "SNY"
                        },
                        new
                        {
                            TickerId = -99,
                            Name = "AMAT"
                        });
                });

            modelBuilder.Entity("Stocks.Server.Models.DTO.TickerDataPoint", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("TickerName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Close")
                        .HasColumnType("real");

                    b.Property<float>("High")
                        .HasColumnType("real");

                    b.Property<float>("Low")
                        .HasColumnType("real");

                    b.Property<float>("Open")
                        .HasColumnType("real");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Date", "TickerName");

                    b.ToTable("ticker_data_points");
                });

            modelBuilder.Entity("Stocks.Server.Models.DTO.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Stocks.Server.Models.DTO.WatchTicker", b =>
                {
                    b.Property<int>("WatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TickerName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WatchId");

                    b.HasIndex("UserId");

                    b.ToTable("watchlist");
                });

            modelBuilder.Entity("Stocks.Server.Models.DTO.WatchTicker", b =>
                {
                    b.HasOne("Stocks.Server.Models.DTO.User", "User")
                        .WithMany("Watchlist")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Stocks.Server.Models.DTO.User", b =>
                {
                    b.Navigation("Watchlist");
                });
#pragma warning restore 612, 618
        }
    }
}
