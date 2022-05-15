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

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.Cookie.Name = "News.Identity-GV";
                cfg.LoginPath = "/Auth/Login";
                cfg.LogoutPath = "/Auth/Logout";
                cfg.Cookie.HttpOnly = true;
                cfg.ExpireTimeSpan = System.TimeSpan.FromDays(30);
                cfg.SlidingExpiration = false;
                cfg.Cookie.SameSite = SameSiteMode.Strict;
                cfg.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            services
                .AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
