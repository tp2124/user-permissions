namespace UserPermissions.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public PermissionFeature PermissionFeature { get; set; }
        public int PermissionFeatureId { get; set; }
    }
}