using AutoMapper;
using UserManagementService.Dtos.ChiliUser;
using UserManagementService.Models;

namespace UserManagementService.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<ChiliUser, ChiliUserDto>();
            CreateMap<ChiliUser, ChiliUserAdminViewDto>();
            CreateMap<ChiliUser, ChiliUserNameDto>();
            CreateMap<ChiliUser, ChiliRecoveryDto>();
        }
    }
}
