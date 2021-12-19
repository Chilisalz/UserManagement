using UserManagementService.Dtos;

namespace UserManagementService.Responses
{
    public class ChiliListResponse<T> : ChiliResponse<T>
    {
        public Pagination Pagination { get; set; }
    }
}
