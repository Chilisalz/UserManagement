using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class InvalidJwtException : Exception
    {
        public InvalidJwtException()
        {

        }

        public InvalidJwtException(string message) : base(message)
        {

        }

        public InvalidJwtException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
