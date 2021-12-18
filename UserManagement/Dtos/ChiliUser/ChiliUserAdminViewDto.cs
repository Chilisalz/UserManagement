using System;

namespace UserManagementService.Dtos.ChiliUser
{
    public class ChiliUserAdminViewDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
