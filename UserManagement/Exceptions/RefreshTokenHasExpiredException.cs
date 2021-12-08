using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenHasExpiredException : Exception
    {
        public RefreshTokenHasExpiredException()
        {

        }

        public RefreshTokenHasExpiredException(string message) : base(message)
        {

        }

        public RefreshTokenHasExpiredException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
