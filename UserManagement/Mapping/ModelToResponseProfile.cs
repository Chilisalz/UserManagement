using AutoMapper;
using UserManagementService.Dtos;
using UserManagementService.Models;
using UserManagementService.Services.ServiceResult;

namespace UserManagementService.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<ChiliUser, ChiliUserDto>();
            CreateMap<ChiliUser, ChiliUserAdminViewDto>();
            CreateMap<GetUsersResult, GetUsersResultDto>();
        }
    }
}
