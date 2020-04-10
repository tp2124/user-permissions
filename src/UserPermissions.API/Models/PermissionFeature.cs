using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class PermissionFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> PermittedUsers { get; set; }
        public List<UserGroup> PermittedUserGroups { get; set; }
    }
}