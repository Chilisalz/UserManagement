using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Options
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
