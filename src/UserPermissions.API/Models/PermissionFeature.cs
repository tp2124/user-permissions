using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class PermissionFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> PermittedUsers { get; set; }
        // public ICollection<UserGroup> PermittedUserGroups { get; set; }
    }
}