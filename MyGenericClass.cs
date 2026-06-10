using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class GenericClass<T>
    {
        private T data;

        //Constructor to initialize the generic class with a value of type T
        public GenericClass(T value) 
        {
            data = value;

        }
        // Method to get the value of type T
        public T GetValue()
        {
            return data;
        }
        // Method to set the value of type T
        public void SetValue(T value)
        {
            data = value;
        }
    }
    internal class MyGenericClass
    {
        GenericClass<int> intobj = new GenericClass<int>(10);
        Console.WriteLine(intobj.) // Output: 10

        GenericClass<string> stringobj = new GenericClass<string>("Hello, World!");
        Console.WriteLine(stringobj.GetValue()); // Output: Hello, World!

    }
}


//write a program to have custom based sorting on the basis of
// salary, joining date and employee id. for an employee class