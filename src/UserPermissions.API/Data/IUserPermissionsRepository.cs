using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public interface IUserPermissionsRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        // Returns false if nothing was saved to the database
        Task<bool> SaveAll();

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<PermissionFeature>> GetPermissionFeatures();
        Task<PermissionFeature> GetPermissionFeature(int id);
    }
}