using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.ToTable("shelf", "library").HasKey(x => x.Id);

            builder.HasOne<Bookcase>(x => x.Bookcase)
                .WithMany(x => x.Shelves)
                .HasForeignKey(x => x.BookcaseId);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.BookcaseId).HasColumnName("bookcase_id").IsRequired();
            builder.Property(x => x.CountBooks).HasColumnName("count_books").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(500).IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").IsRequired();
        }
    }
}