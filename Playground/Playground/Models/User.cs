using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl => $"http://lorempixel.com/200/200/people/{Id}";
    }
}
