using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    internal class Sorting
    {
        public static void Main1()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, };
            Console.WriteLine("Original array:");
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }

            Array.Sort(numbers);
            Console.WriteLine("\n Sorted array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

        }

        public static void Main()
        {
            List<int> numbers = new List<int> { 5, 2, 8, 1, 4 };
            Console.WriteLine("Original list:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            //Sorting the list in ascending order
            numbers.Sort();
            Console.WriteLine("\n Sorted list:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            //Sorting descending order (using reverse after sort)
            numbers.Sort();
            numbers.Reverse();

            Console.WriteLine("\n Sorted list in descending order:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }




        }

    }
}
