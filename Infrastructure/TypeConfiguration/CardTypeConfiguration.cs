using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfiguration;
internal class CardTypeConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Pin)
            .HasMaxLength(4)
            .IsUnicode(false);

        builder.Property(e => e.Number)
            .HasMaxLength(16)
            .IsUnicode(false);

        builder.Property(e => e.IsLocked)
            .HasDefaultValue(false);

        builder.Property(e => e.Attempts);

        builder.Property(e => e.Balance)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.DueDate);

        builder.HasIndex(e => e.Number).IsUnique();

        builder.HasData(GetTestData());
    }

    public static Card[] GetTestData() => new[] 
    {
        new Card 
        {
            Id = Guid.NewGuid(),
            DueDate = new DateTime(2025, 3, 1),
            Number = "1111111111111111",
            Pin = "1234",
            Balance = 50_000
        },
        new Card
        {
            Id = Guid.NewGuid(),
            DueDate = new DateTime(2021, 3, 1),
            Number = "2222222222222222",
            Pin = "4321",
            Balance = 30_000
        },
        new Card
        {
            Id = Guid.NewGuid(),
            DueDate = DateTime.Now.AddMinutes(5),
            Number = "3333333333333333",
            Pin = "6789",
            Balance = 6_000
        }
    };
}
