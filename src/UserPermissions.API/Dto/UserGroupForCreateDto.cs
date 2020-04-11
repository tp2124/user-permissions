using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserPermissions.API.Dto
{
    public class UserGroupForCreateDto
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<int> IncludedUserIds { get; set; }
        public IEnumerable<int> IncludedUserGroupIds { get; set; }
    }
}