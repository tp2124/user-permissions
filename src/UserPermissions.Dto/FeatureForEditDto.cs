using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserPermissions.Dto
{
    public class FeatureForEditDto
    {
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public IEnumerable<int> UserIds { get; set; }
        [Required]
        public IEnumerable<int> UserGroupIds { get; set; }
    }
}