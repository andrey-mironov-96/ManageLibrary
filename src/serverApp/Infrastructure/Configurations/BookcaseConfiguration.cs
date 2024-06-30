using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookcaseConfiguration : IEntityTypeConfiguration<Bookcase>
    {
        public void Configure(EntityTypeBuilder<Bookcase> builder)
        {
            builder.ToTable("bookcase", "library").HasKey(_ => _.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").IsRequired();
            builder.Property(x => x.MaxSizeShelves).HasColumnName("max_size_shelves").IsRequired();
        }
    }
}