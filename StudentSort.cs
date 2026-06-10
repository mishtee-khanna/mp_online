using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{

    class Student : IComparable<Student> // Implementing IComparable to allow sorting by Name
    {
        public string Name { get; set; }
        public int RollNo { get; set; }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }

        public int Compare(Student x, Student y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Name.CompareTo(y.Name);
        }
    }

    class Customer : IComparable<Customer>
    {
        public string CustomerID { get; set; }
        public int Age{ get; set; }

        public int CompareTo(Customer other)
        {
            if(other == null) return 1;
            return this.Age.CompareTo(other.Age);
        }
    }
    internal class StudentSort
    {
        public static void Test()
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Charlie", RollNo = 23 },
                new Student { Name = "Alice", RollNo = 20 },
                new Student { Name = "Bob", RollNo = 10 }
            };
            students.Sort(); // Uses the CompareTo method to sort by Name

            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Roll No: {student.RollNo}");
            }


        }

        public static void Test2()
        {
            List<Customer> customers = new List<Customer>();
            Console.Write("Enter number of customers:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter Customer ID and Age for customer {i + 1}:");
                string[] input = Console.ReadLine().Split(' ');
                customers.Add(new Customer { CustomerID = input[0], Age = int.Parse(input[1]) });
            }

            customers.Sort(); // Uses the CompareTo method to sort by Age
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}, Age: {customer.Age}");
            }
        }


    }
}
