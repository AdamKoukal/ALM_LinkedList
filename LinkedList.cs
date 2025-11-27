using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALM_LinkedList
{
    internal class LinkedList
    {
        public Item FirstItem = null;

        public Item LastItem = null;

        public int Count
        {
            get
            {
                int count = 0;
                Item helpCount;
                if (FirstItem != null)
                {
                    helpCount = FirstItem.copy();

                    while (helpCount != null)
                    {
                        helpCount = helpCount.NextItem;
                        count++;
                    }
                }


                return count;
            }
        }
        public Item addAfter(Item selectedItem, Item item)
        {
            if (FirstItem == null && LastItem == null)
            {
                return addFirst(item);
            }
            else if (FirstItem == LastItem)
            {

                return addLast(item);

            }
            else
            {
                if (selectedItem == FirstItem)
                {
                    this.FirstItem.NextItem.PrevItem = item;
                    item.NextItem = this.FirstItem.NextItem;
                    item.PrevItem = this.FirstItem;
                    this.FirstItem.NextItem = item;

                    return item;
                }
                else if (selectedItem == LastItem)
                {
                    return addLast(item);
                }
                else
                {
                    selectedItem.NextItem.PrevItem = item;
                    item.PrevItem = selectedItem;

                    item.NextItem = selectedItem.NextItem;

                    selectedItem.NextItem = item;
                    return item;
                }

            }


        }

        public Item addBefore(Item selectedItem, Item item)
        {
            if (FirstItem == null && LastItem == null)
            {
                return addFirst(item);
            }
            else if (FirstItem == LastItem)
            {
                return addFirst(item);
            }
            else
            {
                if (selectedItem == FirstItem)
                {
                    return addFirst(item);
                }
                else if (selectedItem == LastItem)
                {


                    item.NextItem = LastItem;
                    item.PrevItem = LastItem.PrevItem;

                    LastItem.PrevItem.NextItem = item;
                    LastItem.PrevItem = item;

                    return item;
                }
                else
                {
                    item.NextItem = selectedItem;
                    item.PrevItem = selectedItem.PrevItem;
                    item.PrevItem.NextItem = item;

                    selectedItem.PrevItem = item;
                    return item;
                }
            }

        }

        public Item addFirst(Item item)
        {


            //Item helpItem = item;

            item.NextItem = this.FirstItem;

            item.PrevItem = null;

            if (this.FirstItem != null)
            {
                this.FirstItem.PrevItem = item;
            }


            this.FirstItem = item;

            if (LastItem == null)
            {
                LastItem = item;
            }
            return item;

        }

        public Item addLast(Item item)
        {
            if (this.LastItem != null)
            {
                this.LastItem.NextItem = item;

                this.LastItem.NextItem.PrevItem = this.LastItem;

                this.LastItem = item;
            }
            else
            {
                LastItem = item;
                FirstItem = item;
            }

            return item;

        }

        public void removeFirst()
        {

            if (this.FirstItem == null && this.LastItem == null)
            {
            }
            else if (this.FirstItem != this.LastItem)
            {
                this.FirstItem = this.FirstItem.NextItem;
                try
                {
                    this.FirstItem.PrevItem = null;
                }
                catch
                {

                }
            }
            else
            {
                FirstItem = null;
                LastItem = null;
            }




        }

        public void removeLast()
        {
            if (this.FirstItem == null && this.LastItem == null)
            {

            }
            else if (this.FirstItem != this.LastItem)
            {
                this.LastItem.PrevItem.NextItem = null;
                this.LastItem = this.LastItem.PrevItem;
            }
            else
            {
                FirstItem = null;
                LastItem = null;
            }

        }

        public void removeSelected(Item selectedItem)
        {

            if (Count == 0)
            {

            }
            else if (Count == 1)
            {

                removeFirst();
            }
            else if (Count == 2)
            {

                Console.WriteLine(selectedItem.Value.Text);
                Console.WriteLine(FirstItem.Value.Text);
                if (selectedItem == FirstItem)
                {

                    removeFirst();
                }
                else
                {

                    removeLast();
                }
            }
            else
            {

                if (selectedItem == FirstItem)
                {

                    removeFirst();
                }
                else if (selectedItem == LastItem)
                {

                    removeLast();
                }
                else
                {


                    Item helpItem = FirstItem.copy().NextItem;
                    while (helpItem != null)
                    {

                        helpItem = helpItem.NextItem;
                        if (helpItem == selectedItem)
                        {


                            selectedItem.PrevItem.NextItem = selectedItem.NextItem;

                            selectedItem.NextItem.PrevItem = selectedItem.PrevItem;

                            selectedItem = null;
                            break;

                        }
                    }
                    
                }
                

            }
        }
            /*public void addLastOld(Item item) 
            {
                Item helpItem = null;
                if (this.FirstItem != null)
                {
                    helpItem = FirstItem;
                    Console.WriteLine("a");
                    while (helpItem.NextItem != null)
                    {
                        helpItem = helpItem.NextItem;
                        Console.WriteLine("b");
                    }
                }


                item.NextItem = null;
                item.PrevItem = helpItem;
                try
                {
                    item.PrevItem.NextItem = item;

                }
                catch
                {

                }


                LastItem = item;
                if (FirstItem == null)
                {
                    FirstItem = item;
                }
            }*/


        
    }
}
