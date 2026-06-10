using System;
using System.Collections.Generic;
using System.Text;
//Write a program to show oldest to newest orders as well as newest to oldest orders. You can use a list of strings to represent the orders, where each string contains the order date in the format "YYYY-MM-DD" followed by the order details. Implement a custom comparer to sort the orders based on their dates.

namespace Collections
{
    class PriorityDate : IComparer<string>
    {
        public string OrderId { get; set; }
        public string Date { get; set; }
        public int Compare(string x, string y)
        {
            // Extract the date part from the order string
            string dateX = x.Split(' ')[0];
            string dateY = y.Split(' ')[0];
            // Parse the dates
            DateTime orderDateX = DateTime.Parse(dateX);
            DateTime orderDateY = DateTime.Parse(dateY);
            // Compare the dates
            return orderDateX.CompareTo(orderDateY);
        }
    }


    internal class Order
    {
        public void ShowOrders()
        {
            List<string> orders = new List<string>
             {
                 "2023-01-15 ORD001: Order details for ORD001",
                 "2023-02-20 ORD002: Order details for ORD002",
                 "2023-01-10 ORD003: Order details for ORD003"
             };
            // Sort orders from oldest to newest
            orders.Sort(new PriorityDate());
            Console.WriteLine("Orders from Oldest to Newest:");
            foreach (string order in orders)
            {
                Console.WriteLine(order);
            }
            // Sort orders from newest to oldest
            orders.Sort((x, y) => new PriorityDate().Compare(y, x));
            Console.WriteLine("\nOrders from Newest to Oldest:");
            foreach (string order in orders)
            {
                Console.WriteLine(order);
            }
        }

    }

}
