using System;
using System.Net;
using ALM_LinkedList;
namespace MyApp
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            Item selectedItem = null;
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Number of items: " + linkedList.Count);
                if (selectedItem != null)
                {
                    Console.WriteLine("Current item Date: " + selectedItem.Value.Date);
                    Console.WriteLine("Current item Text: "+ selectedItem.Value.Text);
                    //Console.WriteLine("Current item(text): " + selectedItem.Value.Text);
                }
                else
                {
                    Console.WriteLine("Current item(Date,text): No items in linked list!");
                }
                if (linkedList.FirstItem != null)
                {
                    Console.WriteLine("First: " + linkedList.FirstItem.Value.Text);
                }
                else
                {
                    Console.WriteLine("First: " + "null");
                }


                if (linkedList.LastItem != null)
                {
                    Console.WriteLine("Last: " + linkedList.LastItem.Value.Text);
                }
                else
                {
                    Console.WriteLine("Last: " + "null");
                }

                

                Console.WriteLine("");

                Console.WriteLine(" 1 | Add First Item");
                Console.WriteLine(" 2 | Add Last Item");
                Console.WriteLine(" 3 | Remove First Item");
                Console.WriteLine(" 4 | Remove Last Item");
                Console.WriteLine(" 5 | Move to previous item");
                Console.WriteLine(" 6 | Move to next item");
                Console.WriteLine(" 7 | Add after selected item");
                Console.WriteLine(" 8 | Add before selected item");
                Console.WriteLine(" 9 | Delete selected item");
                Console.WriteLine("10 | Select first item");
                Console.WriteLine("11 | Select last item");
                Console.WriteLine("12 | Exit app");

                string input =Console.ReadLine();

                if(input == "1")
                {
                    selectedItem = linkedList.addFirst(addItem());
                    
                }
                else if (input == "2")
                {
                    
                    selectedItem=linkedList.addLast(addItem());
                    
                }
                else if (input == "3")
                {
                    if (deleteCheck() == true)
                    {
                        if (selectedItem == linkedList.FirstItem)
                        {
                            if (linkedList.FirstItem != null && linkedList.FirstItem.NextItem != null)
                            {
                                selectedItem = linkedList.FirstItem.NextItem;
                            }
                            else
                            {
                                selectedItem = null;
                            }


                        }

                        linkedList.removeFirst();
                    }
                    
                    
                }
                else if (input == "4")
                {
                    if(deleteCheck() == true)
                    {
                        if (selectedItem == linkedList.LastItem)
                        {
                            if (linkedList.LastItem != null && linkedList.LastItem.PrevItem != null)
                            {
                                selectedItem = linkedList.LastItem.PrevItem;
                            }
                            else
                            {
                                selectedItem = null;
                            }

                        }

                        linkedList.removeLast();
                    }
                    
                                    
                }
                else if (input == "5")
                {
                    if (selectedItem != null && selectedItem.PrevItem != null)
                    {
                        selectedItem = selectedItem.PrevItem;
                    }
                    else if (selectedItem == null)
                    {
                        Console.WriteLine("No items in linked list");
                    }
                    else
                    {
                        Console.WriteLine("This is the first item in linked list");
                    }

                }
                else if (input == "6")
                {
                  
                    if(selectedItem != null&&selectedItem.NextItem != null)
                    {
                        selectedItem = selectedItem.NextItem;
                        Console.WriteLine("a2");
                    }
                    else if (selectedItem == null)
                    {
                        Console.WriteLine("No items in linked list");
                    }
                    else
                    {
                        Console.WriteLine("This is the last item in linked list");
                    }


                }               
                else if (input == "7")
                {
                    
                    selectedItem= linkedList.addAfter(selectedItem, addItem());
                }
                else if (input == "8")
                {
                    selectedItem=linkedList.addBefore(selectedItem, addItem());
                }
                else if (input == "9")
                {
                    Item helpItem = null;
                    if (selectedItem == linkedList.FirstItem)
                    {
                        if (linkedList.FirstItem != null && linkedList.FirstItem.NextItem != null)
                        {
                            helpItem = linkedList.FirstItem.NextItem;
                        }
                        else
                        {
                            helpItem = null;
                        }
                    }
                    else if (selectedItem == linkedList.LastItem)
                    {
                        if (linkedList.LastItem != null && linkedList.LastItem.PrevItem != null)
                        {
                            helpItem = linkedList.LastItem.PrevItem;
                        }
                        else
                        {
                            helpItem = null;
                        }
                    }
                    else
                    {
                        helpItem = selectedItem.PrevItem;
                    }
                    linkedList.removeSelected(selectedItem);
                    selectedItem = helpItem;
                }
                else if (input == "10")
                {
                    selectedItem = linkedList.FirstItem;
                }
                else if (input == "11")
                {
                    selectedItem = linkedList.LastItem;
                }
                else if (input == "12")
                {
                    Environment.Exit(0);
                    
                }

            }
            
            


        }
        public static Item addItem()
        {
            Console.WriteLine();
            Console.WriteLine("Write date (DD.MM.YYYY)");
            DateOnly date;
            while (!DateOnly.TryParse(Console.ReadLine(),out date))
            {
                Console.WriteLine("Wrong input");
            }
            

            //DateOnly date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); //Testování
            Console.WriteLine(date);

            Console.WriteLine("Write text (type "+'"'+"save"+'"'+" to end)");
            string text = "";
            string helpText = "";
            while (helpText != "save")
            {
                helpText=Console.ReadLine();

                if (helpText != "save")
                {
                    text += "\n" + helpText;
                }
                
            }
            

            Record record = new Record();
            record.Date = date;
            record.Text = text;
            Item item = new Item();
            item.Value = record;
            return item;
            
        }

        public static bool deleteCheck()
        {
            Console.WriteLine("Are you really sure to delete this item? (Y/N)");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
