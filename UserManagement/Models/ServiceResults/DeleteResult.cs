using System;

namespace UserManagementService.Models.ServiceResults
{
    public class DeleteResult : BaseServiceResult
    {
        public Guid UserId { get; set; }
    }
}
