using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; } = null!;
    public DbSet<OperationType> OperationTypes { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly, type => type.Namespace is not null && type.Namespace.Contains("TypeConfiguration"));
    }
}
