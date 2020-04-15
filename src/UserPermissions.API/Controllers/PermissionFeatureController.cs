using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IUserPermissionsRepository _repo;
        private readonly IMapper _mapper;

        public PermissionFeatureController(IUserPermissionsRepository repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionFeature(int id)
        {
            var permissionFeature = await _repo.GetPermissionFeature(id);
            var pfToReturn = _mapper.Map<FeatureForDetailedDto>(permissionFeature);
            return Ok(pfToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetPermissionFeatures() {
            var permissionFeatures = await _repo.GetPermissionFeatures();
            var pfsToReturn = _mapper.Map<IEnumerable<FeatureForListDto>>(permissionFeatures);
            return Ok(pfsToReturn);
        }

        // [HttpPost()]
        // public async Task<IActionResult> CreatePermissionFeature(FeatureForCreateDto featureForCreateDto)
        // {
        //     if (!ModelState.IsValid) 
        //         return BadRequest(ModelState);

        //     featureForCreateDto.FeatureName = featureForCreateDto.FeatureName.ToLower();

        //     if (await _context.PermissionFeatures.AnyAsync(pf => pf.Name.Equals(featureForCreateDto.FeatureName))) 
        //         return BadRequest("Permission Feature already exists.");
            
        //     // TODO: Make a repo to hold the logic for this to avoid having this code be limited to only this controller.
        //     // var createdFeature = _repo.CreatePermissionFeature(featureForCreateDto);
        //     // --- Abstract this logic ---
        //     ICollection<User> permittedExistingUsers = new List<User>();
        //     ICollection<UserGroup> permittedExistingUserGroups = new List<UserGroup>();

        //     if (featureForCreateDto.UsernamesAllowed != null) {
        //         foreach (string includedUser in featureForCreateDto.UsernamesAllowed) {
        //             User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(includedUser.ToLower()));
        //             if (existingUser != null) {
        //                 permittedExistingUsers.Add(existingUser);
        //             }
        //         }
        //     }

        //     if (featureForCreateDto.UserGroupsAllowed != null) {
        //         foreach (string includedUserGroup in featureForCreateDto.UserGroupsAllowed) {
        //             UserGroup existingUserGroup = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.Name.Equals(includedUserGroup));
        //             if (existingUserGroup != null) {
        //                 permittedExistingUserGroups.Add(existingUserGroup);
        //             }
        //         }
        //     }

        //     PermissionFeature createdFeature = new PermissionFeature{
        //         Name = featureForCreateDto.FeatureName,
        //         PermittedUsers = permittedExistingUsers,
        //         PermittedUserGroups = permittedExistingUserGroups
        //     };
        //     await _context.PermissionFeatures.AddAsync(createdFeature);
        //     await _context.SaveChangesAsync();
        //     // --- End abstract this logic ---
        //     return Ok(createdFeature);
        // }

        // [HttpPut()]
        // public async Task<IActionResult> Edit(FeatureForEditDto editFeatureReq) {
        //     PermissionFeature editingPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Id == editFeatureReq.FeatureId);
        //     if (editingPermissionFeature == null)
        //         return Ok("Unable to find matching Permission Feature.");

        //     await _context.Entry(editingPermissionFeature)
        //         .Collection(pf => pf.PermittedUsers)
        //         .LoadAsync();
        //     await _context.Entry(editingPermissionFeature)
        //         .Collection(pf => pf.PermittedUserGroups)
        //         .LoadAsync();

        //     HashSet<int> hashedIncludedUserIds = new HashSet<int>(editFeatureReq.UserIds);
        //     HashSet<int> hashedIncludedUserGroups = new HashSet<int>(editFeatureReq.UserGroupIds);

        //     editingPermissionFeature.PermittedUsers = await _context.Users.Where(u => hashedIncludedUserIds.Contains(u.Id)).ToListAsync();
        //     editingPermissionFeature.PermittedUserGroups = await _context.UserGroups.Where(ug => hashedIncludedUserGroups.Contains(ug.Id)).ToListAsync();

        //     await _context.SaveChangesAsync();

        //     return Ok(editingPermissionFeature);
        // }

        // [HttpDelete()]
        // public async Task<IActionResult> Delete(BasicFeatureDto deleteFeatureReq)
        // {
        //     PermissionFeature deletedPermissionFeature = await _context.PermissionFeatures.FirstOrDefaultAsync(pf => pf.Id == deleteFeatureReq.Id);
        //     if (deletedPermissionFeature == null || !deletedPermissionFeature.Name.Equals(deleteFeatureReq.FeatureName, StringComparison.OrdinalIgnoreCase)) {
        //         return Ok("Unable to find matching Permission Feature.");
        //     }

        //     // Use .Reference instead of .Collection for related data that is a single item and not a list.
        //     // https://docs.microsoft.com/en-us/ef/core/querying/related-data
        //     await _context.Entry(deletedPermissionFeature)
        //         .Collection(pf => pf.PermittedUsers)
        //         .LoadAsync();
                
        //     await _context.Entry(deletedPermissionFeature)
        //         .Collection(pf => pf.PermittedUserGroups)
        //         .LoadAsync();

        //     _context.PermissionFeatures.Remove(deletedPermissionFeature);
        //     await _context.SaveChangesAsync();

        //     return Ok(deletedPermissionFeature);
        // }
    }
}