using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace News.Application
{
    public static class DIConfigurator
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
