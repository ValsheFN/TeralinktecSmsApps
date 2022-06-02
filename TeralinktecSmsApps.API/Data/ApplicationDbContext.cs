using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeralinktecSmsApps.API.Models;

namespace TeralinktecSmsApps.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(p => p.CreatedContact)
                .WithOne(p => p.CreatedByUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(p => p.UpdatedContact)
                .WithOne(p => p.UpdatedByUser)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        private string _userId = "";

        public async Task SaveChangesAsync(string userId)
        {
            _userId = userId;
            await SaveChangesAsync();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Record)
                {
                    var userRecord = (Record)item.Entity;

                    switch (item.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            break;
                        case EntityState.Modified:
                            userRecord.UpdateDate = DateTime.Now;
                            userRecord.UpdatedByUserId = _userId;
                            break;
                        case EntityState.Added:
                            userRecord.CreationDate = DateTime.Now;
                            userRecord.CreatedByUserId = _userId;
                            break;
                        default:
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
