using System.Collections.Generic;
using UserPermissions.API.Models;

namespace UserPermissions.API.Dto
{
    public class FeatureForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserForDetailedFeatureDto> PermittedUsers { get; set; }
    }
}