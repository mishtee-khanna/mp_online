using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ConsoleApp
{
    internal class lambdaExample
    {
        public void Application()
        {
            List<int> numbers = new List<int> { 1 , 2 , 3 ,4 , 5};
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine("Even Numbers:" + string.Join(", ", evenNumbers));


            Func<int,int> square = x =>
            {
                Console.Write("Squaring : " + x);
                return x * x;
            };

            Console.WriteLine(square(4));


        }

        //public void applicationProcess()
        //{
        //    ProcessNumbers(new List<int> { 10, 15, 20 }, n => n > 12);
        //}

        public static void test()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenSquares = numbers.Where(n => n % 2 == 0).Select(n => n * n);
        }

        public void Employees()
        {
            var employees = new[]
        {
            new { Name = "Rahul", Salary = 8000 },
            new { Name = "Priya", Salary = 12000 },
            new { Name = "Aman", Salary = 15000 },
            new { Name = "Neha", Salary = 9000 }
        };

            var result = employees.Where(e => e.Salary > 10000);

            Console.WriteLine("Employees earning more than 10000:");

            foreach (var emp in result)
            {
                Console.WriteLine(emp.Name + " - " + emp.Salary);
            }
        }

    }
}
