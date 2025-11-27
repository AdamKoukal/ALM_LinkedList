using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALM_LinkedList
{
    internal class Item
    {
        public Record Value;

        public Item PrevItem;
        public Item NextItem;

        public Item copy()
        {
            return (Item) this.MemberwiseClone();
        }
    }
}
