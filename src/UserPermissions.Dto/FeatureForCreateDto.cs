using System.ComponentModel.DataAnnotations;

namespace UserPermissions.Dto
{
    public class FeatureForCreateDto
    {
        [Required]
        public string FeatureName { get; set; }

        public string[] UsernamesAllowed { get; set; }
        
        public string[] UserGroupsAllowed { get; set; }
    }
}