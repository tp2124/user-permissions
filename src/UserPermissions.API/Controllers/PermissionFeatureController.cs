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

#region Read-Only Endpoints

#region Individual Items
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var matchingPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Id == id);
            return Ok(matchingPermissionFeature);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string featureName) {
            var matchingPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Name.Equals(featureName));
            return Ok(matchingPermissionFeature);
        }
#endregion // Individual Items

#region Multiple Items
        [HttpGet()]
        public async Task<IActionResult> PermissionFeatures() {
            return Ok(await _context.PermissionFeatures
                .Include(pf => pf.PermittedUsers)
                .Include(pf => pf.PermittedUserGroups)
                .ToListAsync());
        }

        [HttpGet("names")]
        public async Task<IActionResult> PermissionFeatureNames() {
            var names = await _context.PermissionFeatures.Select(pf => pf.Name).ToListAsync();
            return Ok(names);
        }
#endregion // Multiple Items

#endregion // Read-Only

#region Editing Endpoints
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

        // DELETE api/values/5
        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] BasicFeatureDto deleteFeatureReq)
        {
            PermissionFeature deletedPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Id == deleteFeatureReq.Id);
            if (deletedPermissionFeature == null || !deletedPermissionFeature.Name.Equals(deleteFeatureReq.FeatureName, StringComparison.OrdinalIgnoreCase)) {
                return Ok("Unable to find matching Permission Feature.");
            }

            if (deletedPermissionFeature != null) {
                // Use .Reference instead of .Collection for related data that is a single item and not a list.
                // https://docs.microsoft.com/en-us/ef/core/querying/related-data
                _context.Entry(deletedPermissionFeature)
                    .Collection(pf => pf.PermittedUsers)
                    .Load();
                    
                _context.Entry(deletedPermissionFeature)
                    .Collection(pf => pf.PermittedUserGroups)
                    .Load();

                _context.PermissionFeatures.Remove(deletedPermissionFeature);
                await _context.SaveChangesAsync();
            }
            return Ok(deletedPermissionFeature);
        }
#endregion
    }
}