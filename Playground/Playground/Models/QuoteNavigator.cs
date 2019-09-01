using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Models
{
    public class QuoteNavigator
    {
        public string Quote { get; set; }
        public int FontSize { get; set; }
        public bool CanGoForward { get; set; }
        public bool CanGoBack { get; set; }
    }
}
