using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(IEnumerable<int> userIds);
    }
}