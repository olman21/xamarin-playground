using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl => $"http://lorempixel.com/100/100/people/{UserId}";

    }
}
