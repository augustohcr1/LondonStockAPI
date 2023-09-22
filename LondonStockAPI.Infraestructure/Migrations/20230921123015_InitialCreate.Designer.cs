﻿// <auto-generated />
using System;
using LondonStockAPI.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LondonStockAPI.Infraestructure.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20230921123015_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LondonStockAPI.Domain.Stock", b =>
                {
                    b.Property<string>("TickerSymbol")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TickerSymbol");

                    b.ToTable("Stocks", (string)null);
                });

            modelBuilder.Entity("LondonStockAPI.Domain.StockTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrokerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NumberOfShares")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TickerSymbol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("TransactionTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TickerSymbol");

                    b.ToTable("StockTransactions", (string)null);
                });

            modelBuilder.Entity("LondonStockAPI.Domain.StockTransaction", b =>
                {
                    b.HasOne("LondonStockAPI.Domain.Stock", "Stock")
                        .WithMany("StockTransactions")
                        .HasForeignKey("TickerSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("LondonStockAPI.Domain.Stock", b =>
                {
                    b.Navigation("StockTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
