using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class SecretQuestionNotFoundException : Exception
    {
        public SecretQuestionNotFoundException()
        {

        }

        public SecretQuestionNotFoundException(string message) : base(message)
        {

        }

        public SecretQuestionNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
