using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissions.API.Models;

namespace UserPermissions.API.Data
{
    public interface IUserGroupRepository
    {
        Task<IEnumerable<UserGroup>> GetUserGroups(IEnumerable<int> userGroupIds);
    }
}