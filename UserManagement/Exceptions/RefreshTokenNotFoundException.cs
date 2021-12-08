using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenNotFoundException : Exception
    {
        public RefreshTokenNotFoundException()
        {

        }

        public RefreshTokenNotFoundException(string message) : base(message)
        {

        }

        public RefreshTokenNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
