namespace UserPermissions.API.Models
{
    public class PermissionFeatureUser
    {
        public int PermissionFeatureId { get; set; }
        public PermissionFeature PermissionFeature { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}