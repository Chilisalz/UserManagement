using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class EmailAlreadyTakenException : Exception
    {
        public EmailAlreadyTakenException()
        {

        }

        public EmailAlreadyTakenException(string message) : base(message)
        {

        }

        public EmailAlreadyTakenException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
