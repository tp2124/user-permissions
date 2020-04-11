using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly DataContext _context;

        public UserGroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserGroup>> GetUserGroups(IEnumerable<int> userIds)
        {
            if (userIds == null)
                return new List<UserGroup>();

            ISet<int> hashedUserIds = new HashSet<int>(userIds);
            return await _context.UserGroups.Where(u => hashedUserIds.Contains(u.Id)).ToListAsync();
        }
    }
}