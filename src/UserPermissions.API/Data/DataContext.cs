using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionFeatureUser>()
                .HasKey(pfu => new { pfu.PermissionFeatureId, pfu.UserId });  
            modelBuilder.Entity<PermissionFeatureUser>()
                .HasOne(pfu => pfu.PermissionFeature)
                .WithMany(pf => pf.PermissionFeatureUsers)
                .HasForeignKey(pfu => pfu.PermissionFeatureId);  
            modelBuilder.Entity<PermissionFeatureUser>()
                .HasOne(pfu => pfu.User)
                .WithMany(u => u.PermissionFeatureUsers)
                .HasForeignKey(pfu => pfu.UserId);
        }

        public DbSet<PermissionFeature> PermissionFeatures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<PermissionFeatureUser> PermissionFeatureUsers { get; set; }
    }
}