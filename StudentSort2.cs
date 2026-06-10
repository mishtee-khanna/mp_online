using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class Student2// Implementing IComparable to allow sorting by Name
    {
        public string Name { get; set; }
        public int RollNo { get; set; }


        public int Compare(Student2 x, Student2 y)
        {
            // Handle null cases
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Name.CompareTo(y.Name);
        }
    }

    class StudentRollComparer : IComparer<Student2>
    {
        public int Compare(Student2 x, Student2 y)
        {
            // Handle null cases
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.RollNo.CompareTo(y.RollNo);
        }
     
    }

    internal class StudentSort2
    {
        public void Test()
        {
            List<Student2> students = new List<Student2>
            {
                new Student2 { Name = "Charlie", RollNo = 23 },
                new Student2 { Name = "Alice", RollNo = 20 },
                new Student2 { Name = "Bob", RollNo = 10 }
            };
            // Sort by Name using the Compare method in Student2
            students.Sort();


            Console.WriteLine("Sorted by Name:");
            foreach (Student2 student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Roll No: {student.RollNo}");
            }
            // Sort by RollNo using the StudentRollComparer

            students.Sort(new StudentRollComparer());
            Console.WriteLine("\nSorted by Roll No:");
            foreach (Student2 student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Roll No: {student.RollNo}");
            }
        }
    }
}
