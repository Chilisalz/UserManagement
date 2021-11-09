using AutoMapper;
using UserManagementService.Contracts.Responses;
using UserManagementService.Models;

namespace UserManagementService.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<ChiliUser, ChiliUserResponse>();
        }
    }
}
