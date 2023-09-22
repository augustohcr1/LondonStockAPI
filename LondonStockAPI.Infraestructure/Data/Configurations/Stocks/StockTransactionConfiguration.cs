using LondonStockAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStockAPI.Infraestructure.Data.Configurations.Stocks;

public class StockTransactionConfiguration : IEntityTypeConfiguration<StockTransaction>
{
    public void Configure(EntityTypeBuilder<StockTransaction> builder)
    {
        builder.ToTable("StockTransactions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.TickerSymbol)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(t => t.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.NumberOfShares)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(t => t.Stock)
            .WithMany(s => s.StockTransactions)
            .HasForeignKey(t => t.TickerSymbol);
    }
}

