using System;

namespace UserManagementService.Models.ServiceResults
{
    public class ChangePasswordResult : BaseServiceResult
    {
        public Guid UserId { get; set; }
    }
}
