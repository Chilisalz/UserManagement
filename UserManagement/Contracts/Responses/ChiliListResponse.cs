using UserManagementService.Dtos;

namespace UserManagementService.Contracts.Responses
{
    public class ChiliListResponse<T> : ChiliResponse<T>
    {
        public Pagination Pagination { get; set; }
    }
}
