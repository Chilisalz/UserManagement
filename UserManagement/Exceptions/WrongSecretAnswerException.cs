using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Exceptions
{
    public class WrongSecretAnswerException : Exception
    {
        public WrongSecretAnswerException()
        {

        }

        public WrongSecretAnswerException(string message) : base(message)
        {

        }

        public WrongSecretAnswerException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
