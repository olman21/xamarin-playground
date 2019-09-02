using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }

        public string FullName => $"{Name} {LastName}".Trim();
    }
}
