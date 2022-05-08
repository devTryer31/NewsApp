using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace News.Persistence.EntityTypeConfigurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<Domain.News>
    {
        public void Configure(EntityTypeBuilder<Domain.News> builder)
        {
            builder.HasKey(news => news.NewsId);
            builder.HasIndex(news => news.NewsId);
            builder.Property(news => news.Title).HasMaxLength(150);
            builder.Property(news => news.Content).HasDefaultValue(null);
            builder.Property(news => news.CreationDate);
            builder.Property(news => news.LastModifiedDate).HasDefaultValue(null);
        }
    }
}
