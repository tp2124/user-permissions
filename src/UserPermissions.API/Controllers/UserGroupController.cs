using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserPermissions.API.Data;
using UserPermissions.API.Dto;
using UserPermissions.API.Models;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupController(DataContext context, IUserRepository userRepo, IUserGroupRepository userGroupRepo) {
            _context = context;
            _userRepository = userRepo;
            _userGroupRepository = userGroupRepo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetUserGroups()
        {
            return Ok(await _context.UserGroups.ToListAsync()); // Need to use ToList() in order to evaluate the query.
        }

        [HttpGet("detailed")]
        public async Task<IActionResult> GetFullDetailedUserGroups()
        {
            return Ok(await _context.UserGroups
                .Include(ug => ug.IncludedUsers)
                .Include(ug => ug.IncludedUserGroups)
                .ToListAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _context.UserGroups.FirstOrDefaultAsync(u => u.Id == id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(UserGroupForCreateDto newUserGroup)
        {
            newUserGroup.Name = newUserGroup.Name.ToLower();
            if (await _context.UserGroups.AnyAsync(ug => ug.Name.Equals(newUserGroup.Name)))
                return BadRequest("UserGroup already exists with that name.");

            //#2 ----- Move to Repository -----
            UserGroup newDBGroup = new UserGroup {
                Name = newUserGroup.Name,
                IncludedUsers = await _userRepository.GetUsers(newUserGroup.IncludedUserIds),
                IncludedUserGroups = await _userGroupRepository.GetUserGroups(newUserGroup.IncludedUserGroupIds)
            };
            await _context.UserGroups.AddAsync(newDBGroup);
            await _context.SaveChangesAsync();
            //#2 ----- End -----

            return Ok(newDBGroup);
        }

        [HttpPut]
        public async Task<IActionResult> Put(/*UserForEditDto editUser*/)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}