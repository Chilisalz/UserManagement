using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class InvalidatedRefreshTokenException : Exception
    {
        public InvalidatedRefreshTokenException()
        {

        }

        public InvalidatedRefreshTokenException(string message) : base(message)
        {

        }

        public InvalidatedRefreshTokenException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
