using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        private int count = 0;

        private Item lastItem = null;

        public int Count
        {
            get { return count; }
        }

        public Stack Add(object obj)
        {
            Item box = new Item(obj, lastItem);
            lastItem = box;
            count++;
            return this;
        }

        public object RemoveLast()
        {
            if (lastItem == null)
            {
                throw new InvalidOperationException("There are no elements in the stack.");
            }
            Item item = lastItem;
            lastItem = item.PrevItem;
            count--;
            return item.Value;
        }

        public void Clear()
        {
            while (lastItem != null)
            {
                lastItem.Value = null;
                lastItem = lastItem.PrevItem;
            }
            count = 0;
        }

        private class Item
        {
            public Item PrevItem;
            public object Value;

            public Item(object value, Item prevItem)
            {
                this.Value = value;
                this.PrevItem = prevItem;
            }
        }
    }
}
