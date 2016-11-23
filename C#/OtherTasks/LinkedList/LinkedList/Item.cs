using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Item
    {
        public Item PrevItem { get; set; }
        public Item NextItem { get; set; }

        public object Value;

        public Item(object value)
        {
            this.Value = value;
        }
    }
}
