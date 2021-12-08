using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class TokenHasntExpiredException : Exception
    {
        public TokenHasntExpiredException()
        {

        }

        public TokenHasntExpiredException(string message) : base(message)
        {

        }

        public TokenHasntExpiredException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
