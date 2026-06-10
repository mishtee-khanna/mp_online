using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    internal class IEnumExample
    {
        public static void Main()
        {
            IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Numbers in the collection:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            IEnumerable<int> evenNumbers = GetEvenNumbers(numbers);
            Console.WriteLine("Even Numbers : ");
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }


        }

        //Method that uses yield return to generate even numbers from the input collection
        static IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number; // Return even numbers one at a time
                }
            }


        }
    }
}
