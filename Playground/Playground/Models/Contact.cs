using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Playground.Models
{
    public class Contact
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(300)]
        public string Email { get; set; }
        public bool Blocked { get; set; }

        [Ignore]
        public string FullName => $"{Name} {LastName}".Trim();
    }
}
