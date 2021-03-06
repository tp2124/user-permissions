using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<PermissionFeature> PermissionFeatures { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}