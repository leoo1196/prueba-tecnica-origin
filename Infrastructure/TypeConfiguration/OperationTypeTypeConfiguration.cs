using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfiguration;
internal class OperationTypeTypeConfiguration : IEntityTypeConfiguration<OperationType>
{
    public void Configure(EntityTypeBuilder<OperationType> builder)
    {
        builder.ToTable("OperationTypes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.HasData(
            new OperationType { Id = (int)Core.Enums.OperationType.Balance, Description = "Balance" },
            new OperationType { Id = (int)Core.Enums.OperationType.Extraction, Description = "Retiro" }
        );
    }
}
