using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class UsernameAlreadyTakenException : Exception
    {
        public UsernameAlreadyTakenException()
        {

        }

        public UsernameAlreadyTakenException(string message) : base(message)
        {

        }

        public UsernameAlreadyTakenException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
