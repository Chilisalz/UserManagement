using UserManagementService.Services.ServiceResult;

namespace UserManagementService.Contracts.Responses
{
    public class ChiliListResponse<T> : ChiliResponse<T>
    {
        public Pagination Pagination { get; set; }
    }
}
