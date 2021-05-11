using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DisplayItem
    {
        public string Display { get; set; }
        public object Value { get; set; }

        public DisplayItem(string display, object value)
        {
            Display = display;
            Value = value;
        }
    }
}
