using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using News.Application;
using News.Application.Common.Mappings;
using News.Application.Interfaces;
using News.Persistence;
using System;
using System.Linq;
using System.Reflection;

namespace News.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPersistence(Configuration)
                .AddApplication()
                .AddAutoMapper(cfg =>
                {
                    cfg.AddProfile(new AssemblyMappingProfiler(assembly: Assembly.GetExecutingAssembly()));
                    cfg.AddProfile(new AssemblyMappingProfiler(
                        assembly: typeof(INewsDbContext).Assembly
                        //assembly: AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(asbly => asbly.GetName().Name == "News.Application")
                        ));
                })
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
