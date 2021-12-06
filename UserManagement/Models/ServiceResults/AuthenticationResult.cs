namespace UserManagementService.Models.ServiceResults
{
    public class AuthenticationResult : BaseServiceResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
