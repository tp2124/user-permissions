using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class Seed
    {
        // No bother to make this Async as this is only called on start up for seeding.
        public static void SeedUsers(DataContext context) {
            if (context.PermissionFeatures.Any()) {
                return;
            }
            var permissionFeatureData = System.IO.File.ReadAllText("Data/FeaturesSeedData.json");
            var permissionFeatures = JsonConvert.DeserializeObject<List<PermissionFeature>>(permissionFeatureData);
            foreach (var permissionFeature in permissionFeatures) {
                foreach (User user in permissionFeature.PermittedUsers) {
                    user.Username = user.Username.ToLower();
                }
            }
            context.PermissionFeatures.AddRange(permissionFeatures);
            context.SaveChanges();
        }
    }
}