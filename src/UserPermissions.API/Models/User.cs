using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        // Fluent API Support for *-to-many relationships
        public IEnumerable<PermissionFeatureUser> PermissionFeatureUsers { get; set; }
    }
}