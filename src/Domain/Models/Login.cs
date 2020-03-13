using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Login : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
