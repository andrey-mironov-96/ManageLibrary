using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book", "library").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Pages).HasColumnName("pages").IsRequired();
            builder.Property(x => x.Author).HasColumnName("author").HasMaxLength(1000).IsRequired();
        }
    }
}
