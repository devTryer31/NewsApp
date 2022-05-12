using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace News.Identity.Data
{
    public class AuthDbContext : IdentityDbContext<Models.User>
    {
        public AuthDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.User>(entity => entity.ToTable(name: "users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "roles"));
            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "user_roles"));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "users_claims"));
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "users_tokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "role_claims"));

            builder.ApplyConfiguration(new UserDbConfiguration());
        }

        public void Initialize() => this.Database.EnsureCreated();
    }
}
