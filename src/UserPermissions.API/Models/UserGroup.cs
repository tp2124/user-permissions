using System.Collections.Generic;

namespace UserPermissions.API.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> IncludedUsers { get; set; }
        public IEnumerable<UserGroup> IncludedUserGroups { get; set; }
    }
}