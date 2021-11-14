using System;

namespace UserManagementService.Options
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
