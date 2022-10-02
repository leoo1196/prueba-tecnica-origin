using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfiguration;
internal class OperationTypeConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ToTable("Operation");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18,2)");

        builder
            .HasOne(e => e.Card)
            .WithMany(f => f.Operations)
            .HasForeignKey(e => e.CardId);

        builder
            .HasOne(e => e.OperationType)
            .WithMany(f => f.Operations)
            .HasForeignKey(e => e.OperationTypeId);
    }
}
