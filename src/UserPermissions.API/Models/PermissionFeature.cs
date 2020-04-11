using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class PermissionFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserGroup> PermittedUserGroups { get; set; }

        // Fluent API Support for *-to-many relationships
        public IEnumerable<PermissionFeatureUser> PermissionFeatureUsers { get; set; }
    }
}