using System.ComponentModel.DataAnnotations;

namespace UserPermissions.API.Dto
{
    public class BasicFeatureDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FeatureName { get; set; }

    }
}