using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList
    {
        private int count = 0;

        private Item lastItem = null;
        private Item firstItem = null;

        public int Count
        {
            get { return count; }
        }

        public LinkedList Add(object obj)
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
                box.PrevItem = lastItem;
                lastItem = box;
            }
            count++;
            return this;
        }

        public LinkedList Insert(object obj)
        {
            Item box = new Item(obj);
            if (firstItem == null)
            {
                firstItem = box;
                lastItem = box;
            }
            else
            {
                box.NextItem = firstItem;
                firstItem.PrevItem = box;
                firstItem = box;
            }
            count++;
            return this;
        }

        public object this[int position]
        {
            get { return GetItemAtPosition(position).Value; }
            set { GetItemAtPosition(position).Value = value; }
        }

        private Item GetItemAtPosition(int position)
        {
            if (position < 0 || position >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (position < count / 2) ? GetItemBeforeMiddle(position) : GetItemAfterMiddle(position);
        }

        private Item GetItemBeforeMiddle(int positionFromBeginning)
        {
            Item currentItem = firstItem;
            for (int i = 0; i < positionFromBeginning; i++)
            {
                currentItem = currentItem.NextItem;
            }
            return currentItem;
        }

        private Item GetItemAfterMiddle(int positionFromBeginning)
        {
            Item currentItem = lastItem;
            for (int i = count - 1; i > positionFromBeginning; i--)
            {
                currentItem = currentItem.PrevItem;
            }
            return currentItem;
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
            else
            {
                firstItem.PrevItem = null;
            }
            item.NextItem = null;
            count--;
            return item.Value;
        }

        public object RemoveLast()
        {
            if (lastItem == null)
            {
                throw new InvalidOperationException("There are no elements in the stack.");
            }
            Item item = lastItem;
            lastItem = lastItem.PrevItem;
            if (lastItem != null)
            {
                lastItem.NextItem = null;
                item.PrevItem = null;
            }
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
            firstItem = null;
            count = 0;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            Item currentItem = firstItem;
            while (currentItem != null)
            {
                s.Append(currentItem.Value);
                if (currentItem != lastItem)
                {
                    s.Append(", ");
                }
                currentItem = currentItem.NextItem;
            }
            return s.ToString();
        }
    }
}
