using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace Collections
{
    internal class Demo1
    {
        public void m1()
        {
            List<int> number = new List<int>();
            number.Add(1);
            number.Add(2);
            number.Add(3);
            number.Add(4);
            number.Add(5);

            foreach (int i in number)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine(number[1]);
            Console.WriteLine(number[2]);

            number.Remove(2);
            foreach (int i in number)
            {
                Console.Write(i + " ");

            }

            int len = number.Count; // size of list 

            Console.WriteLine(len);
            List<string> cart = new List<string>();
            cart.Add("Mobile");
            cart.Add("Laptop");
            cart.Add("Headphones");
            cart.Add("Keyboard");
            cart.Add("Mouse");

            cart.Remove("Mouse");

            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine("Things in cart:" + cart[i]);
            }

        }

        public static void m2()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>{
                {1, "Ram" } , {2, "Shyam" }, {3, "Mohan" }, {4, "Sohan" }
            };

            dict[3] = "Harish"; // update value of key 3

            foreach (var kvp in dict)
            {
                Console.WriteLine($"ID:{kvp.Key} ,Name:{kvp.Value} ");
            }
        }

        public static void m3()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

        }

        public static void m4()
        {
            HashSet<string> set = new HashSet<string>
            {
                "Seeta" , "Geeta" , "Meeta" , "Reeta"
            };

            foreach (var person in set)
            {
                Console.WriteLine($"Attendee : {person}");
            }
        }

        public static void Driver(string v)
        {

            Dictionary<int, string> students = new Dictionary<int, string>();
            while (true)
            {
                Console.WriteLine("\n===Students Reocord Menu ====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Delete Student by ID");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option (1-5):");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();

                        if (!students.ContainsKey(id))
                        {
                            students[id] = name;
                            Console.WriteLine($"Student added : ID={id}, Name={name}");
                        }
                        else
                        {
                            Console.WriteLine("Student with this ID already exists.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n All Students :");
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            foreach (var kvp in students)
                            {
                                Console.WriteLine($"ID:{kvp.Key} , Name:{kvp.Value}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Student ID to search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        if (students.ContainsKey(searchId))
                        {
                            Console.WriteLine($"Student found : ID={searchId}, Name={students[searchId]}");

                        }
                        else
                        {
                            Console.WriteLine("Student with this ID not found.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Student ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        if (students.Remove(deleteId))
                        {
                            Console.WriteLine($"Student with ID={deleteId} deleted successfully.");

                        }
                        else
                        {
                            Console.WriteLine("Student with this ID not found.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program....");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                        break;

                }
            }



        }

        public static void Main()
        {
            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");

            Console.WriteLine(ht[2]);

            if (ht.ContainsKey(3))
            {
                Console.WriteLine("Key 3 exists in the hashtable.");
            }
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"Key:{entry.Key} , Value:{entry.Value}");
            }
        }
    }
}

