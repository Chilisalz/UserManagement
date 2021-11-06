using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benutzerverwaltung.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }        
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }        
    }
}
