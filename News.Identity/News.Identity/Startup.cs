using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using News.Identity.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace News.Identity
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration appConfiguration)
            => AppConfiguration = appConfiguration;

        public void ConfigureServices(IServiceCollection services)
        {
            string authConnString = AppConfiguration.GetConnectionString("News.IdentityServer");


            services
                .AddDbContext<AuthDbContext>(opt =>
                {
                    opt.UseSqlite(authConnString);
                });

            services
                .AddIdentity<Models.User, IdentityRole>(cfg =>
                {
                    cfg.Password.RequiredLength = 4;
                    cfg.Password.RequireNonAlphanumeric = false;

                }).AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();
                

            services
                .AddIdentityServer()
                .AddAspNetIdentity<Models.User>()
                .AddInMemoryApiResources(Configuration.ApiResources)
                .AddInMemoryApiScopes(Configuration.ApiScopes)
                .AddInMemoryIdentityResources(Configuration.IdentityResources)
                .AddInMemoryClients(Configuration.ClientApps)
                .AddDeveloperSigningCredential(); //Demonstration signature certificate.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
