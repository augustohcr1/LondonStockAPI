using System.Reflection;
using LondonStockAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.Infraestructure;

public class DomainContext : DbContext
{
    public DomainContext(DbContextOptions<DomainContext> options) : base(options)
    { }

    public DomainContext()
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Stock> Stocks { get; set; } = null!;
    public DbSet<StockTransaction> StockTransactions { get; set; } = null!;

}

