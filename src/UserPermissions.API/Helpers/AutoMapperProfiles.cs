using System;
using System.Linq;
using AutoMapper;
using UserPermissions.API.Dto;
using UserPermissions.API.Models;

namespace UserPermissions.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PermissionFeature, FeatureForListDto>();
            CreateMap<PermissionFeature, FeatureForDetailedDto>();
            CreateMap<User, UserForDetailedFeatureDto>();
        }
    }
}