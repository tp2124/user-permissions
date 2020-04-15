using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public ICollection<User> IncludedUsers { get; set; }
        // public ICollection<UserGroup> IncludedUserGroups { get; set; }
    }
}