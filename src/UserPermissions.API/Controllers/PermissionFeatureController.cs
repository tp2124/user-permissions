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
    public class PermissionFeatureController : ControllerBase
    {
        private readonly DataContext _context;

        public PermissionFeatureController(DataContext context) {
            _context = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var matchingPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Id == id);
            return Ok(matchingPermissionFeature);
        }

        [HttpGet("names")]
        public async Task<IActionResult> PermissionFeatureNames() {
            var names = await _context.PermissionFeatures.Select(pf => pf.Name).ToListAsync();
            return Ok(names);
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePermissionFeature(FeatureForCreateDto featureForCreateDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            featureForCreateDto.FeatureName = featureForCreateDto.FeatureName.ToLower();

            if (await _context.PermissionFeatures.AnyAsync(pf => pf.Name.Equals(featureForCreateDto.FeatureName))) 
                return BadRequest("Permission Feature already exists.");
            
            // TODO: Make a repo to hold the logic for this to avoid having this code be limited to only this controller.
            // var createdFeature = _repo.CreatePermissionFeature(featureForCreateDto);
            // --- Abstract this logic ---
            ICollection<User> permittedExistingUsers = new List<User>();
            ICollection<UserGroup> permittedExistingUserGroups = new List<UserGroup>();

            if (featureForCreateDto.UsernamesAllowed != null) {
                foreach (string includedUser in featureForCreateDto.UsernamesAllowed) {
                    User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(includedUser.ToLower()));
                    if (existingUser != null) {
                        permittedExistingUsers.Add(existingUser);
                    }
                }
            }

            if (featureForCreateDto.UserGroupsAllowed != null) {
                foreach (string includedUserGroup in featureForCreateDto.UserGroupsAllowed) {
                    UserGroup existingUserGroup = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.Name.Equals(includedUserGroup));
                    if (existingUserGroup != null) {
                        permittedExistingUserGroups.Add(existingUserGroup);
                    }
                }
            }

            PermissionFeature createdFeature = new PermissionFeature{
                Name = featureForCreateDto.FeatureName,
                PermittedUsers = permittedExistingUsers,
                PermittedUserGroups = permittedExistingUserGroups
            };
            await _context.PermissionFeatures.AddAsync(createdFeature);
            await _context.SaveChangesAsync();
            // --- End abstract this logic ---
            return Ok(createdFeature);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}