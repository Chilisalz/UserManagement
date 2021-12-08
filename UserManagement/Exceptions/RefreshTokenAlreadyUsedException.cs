using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class RefreshTokenAlreadyUsedException : Exception
    {
        public RefreshTokenAlreadyUsedException()
        {

        }

        public RefreshTokenAlreadyUsedException(string message) : base(message)
        {

        }

        public RefreshTokenAlreadyUsedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
