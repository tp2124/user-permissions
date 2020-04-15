using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class UserPermissionsRepository : IUserPermissionsRepository
    {
        private readonly DataContext _context;
        public UserPermissionsRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<PermissionFeature> GetPermissionFeature(int id)
        {
            return await _context.PermissionFeatures
                                .Include(pf => pf.PermittedUsers)
                                .FirstOrDefaultAsync(pf => pf.Id == id);
        }

        public async Task<IEnumerable<PermissionFeature>> GetPermissionFeatures()
        {
            return await _context.PermissionFeatures
                                .Include(pf => pf.PermittedUsers)
                                .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users
                                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users
                                .ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}