using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Type Page { get; set; }
    }
}
