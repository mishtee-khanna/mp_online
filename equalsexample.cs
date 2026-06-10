using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Override Equals method to compare Person2 objects based on Name and Age

        public override bool Equals(object obj)
        {
            if(obj is Person2 other)
            {
                return Name == other.Name && Age == other.Age;
            }
            return false;
        }
    }

    internal class equalsexample
    {
        public void test()
        {
            var p1 = new Person2 { Name = "Test", Age = 30 };
            var p2 = new Person2 { Name = "Test", Age = 30 };
            Console.WriteLine(p2.Equals(p1)); // Output: True

        }
    }
}
