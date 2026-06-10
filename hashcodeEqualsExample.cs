using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class  Person1
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Person1 other)
            {
                return Name == other.Name && Age == other.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }

    internal class hashcodeEqualsExample
    {

        public static void withBothMethods()
        {
            var p1 = new Person1 { Name = "Test", Age = 30 };
            var p2 = new Person1 { Name = "Test", Age = 30 };
            var people = new HashSet<Person1>();
            people.Add(p1);
            people.Add(p2);
            Console.WriteLine(p2.Equals(p1)); // Output: True
        }

        public static void WithoutMethods()
        {
            var p1 = new Person { Name = "Test", Age = 30 };
            var p2 = new Person { Name = "Test", Age = 30 };

            var people = new HashSet<Person>();
            people.Add(p1);
            people.Add(p2);

            Console.WriteLine(p2.Equals(p1)); // Output: False
        }


    }
}
