using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue
    {
        private int count = 0;
        private Item firstItem = null;
        private Item lastItem = null;

        public int Count
        {
            get { return count;  }
        }

        public Queue Add(object obj)
        {
            Item box = new Item(obj);
            if (firstItem == null)
            {
                firstItem = box;
                lastItem = box;
            }
            else
            {
                lastItem.NextItem = box;
                lastItem = box;
            }
            count++;
            return this;
        }

        public object RemoveFirst()
        {
            if (firstItem == null)
            {
                throw new InvalidOperationException("There are no elements in the stack.");
            }
            Item item = firstItem;
            firstItem = firstItem.NextItem;
            if (firstItem == null)
            {
                lastItem = null;
            }
            count--;
            return item.Value;
        }

        public void Clear()
        {
            while (firstItem != null)
            {
                firstItem.Value = null;
                firstItem = lastItem.NextItem;
            }
            count = 0;
        }

        private class Item
        {
            public Item NextItem;
            public object Value;

            public Item(object value)
            {
                this.Value = value;
            }
        }

    }
}
