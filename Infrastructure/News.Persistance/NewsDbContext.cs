using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Persistence.EntityTypeConfigurations;
using System.Threading;
using System.Threading.Tasks;

namespace News.Persistence
{
    public sealed class NewsDbContext : DbContext, INewsDbContext
    {
        public DbSet<Domain.News> News { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public bool Initialize() => Database.EnsureCreated();
    }
}
