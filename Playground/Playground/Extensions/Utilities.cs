using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Playground.Extensions
{
    public static class Utilities
    {
        public static void ToObservableCollection<T>(this ObservableCollection<T> target, IEnumerable<T> source)
        {
            target.Clear();

            if (source != null)
            {
                foreach (var item in source)
                {
                    target.Add(item);
                }
            }
        }

        
    }
}
