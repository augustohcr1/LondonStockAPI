using LondonStockAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LondonStockAPI.Infraestructure.Data.Configurations.Stocks;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");

        builder.HasKey(s => s.TickerSymbol);

        builder.Property(s => s.TickerSymbol)
            .IsRequired()
            .HasMaxLength(10); 

       builder.HasMany(s => s.StockTransactions)
            .WithOne(t => t.Stock)
            .HasForeignKey(t => t.TickerSymbol)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

