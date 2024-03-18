using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NzWalks.API.Data
{
    public class NzWalksAuthDbContext : IdentityDbContext
    {
        // Tipa o DbContextOpt por causa, que temos dois dbContexts
        public NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> dbContextAuthOptions) : base(dbContextAuthOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerRoleId = "c0696108-8283-4632-b8a0-80bafc95744c";
            var writerRoleId = "b9e12958-f484-48e5-a55b-bac8a1d52a1b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }

    // Add-Migration "Create Auth Database" -Context "NzWalksAuthDbContext"
    // Update-Database -Context "NzWalksAuthDbContext"
}
