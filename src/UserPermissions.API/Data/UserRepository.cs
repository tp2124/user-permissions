using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers(IEnumerable<int> userIds)
        {
            if (userIds == null) 
                return new List<User>();

            ISet<int> hashedUserIds = new HashSet<int>(userIds);
            return await _context.Users.Where(u => hashedUserIds.Contains(u.Id)).ToListAsync();
        }
    }
}