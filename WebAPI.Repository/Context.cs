 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebAPI.Repository
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>();

            builder.Entity<Organizacao>(org =>
            {
                org.ToTable("Organizacoes");
                org.HasKey(x => x.Id);

                org.HasMany<User>()
                    .WithOne()
                    .HasForeignKey(x => x.OrgId)
                    .IsRequired(false);
            });
        }
    }
}