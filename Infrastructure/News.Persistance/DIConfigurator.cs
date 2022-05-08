using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Interfaces;

namespace News.Persistence
{
    public static class DIConfigurator
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("SQLite");
            services.AddDbContext<INewsDbContext, NewsDbContext>(opt => opt.UseSqlite(connString));

            return services;
        }
    }
}
