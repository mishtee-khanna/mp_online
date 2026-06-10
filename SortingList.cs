using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    internal class SortingList
    {
        public static void LL()
        {
            LinkedList<string> fruits = new LinkedList<string>();
            //Adding fruits to the linked list

            fruits.AddLast("Apple");
            fruits.AddLast("Banana");
            fruits.AddLast("Cherry");
            fruits.AddLast("Date");

            //Iterating through the linked list and displaying the fruits
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            //Access first and last fruit

            


        }

        
    }
}