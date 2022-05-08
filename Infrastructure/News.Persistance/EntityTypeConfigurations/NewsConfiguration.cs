using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace News.Persistence.EntityTypeConfigurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<Domain.News>
    {
        public void Configure(EntityTypeBuilder<Domain.News> builder)
        {
            builder.HasKey(news => news.Id);
            builder.HasIndex(news => news.Id);
            builder.Property(news => news.Title).HasMaxLength(150);
            builder.Property(news => news.Content).HasDefaultValue(null);
            builder.Property(news => news.CreationDate);
            builder.Property(news => news.LastModifiedDate).HasDefaultValue(null);
        }
    }
}
