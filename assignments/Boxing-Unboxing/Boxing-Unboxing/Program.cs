using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> myList = new List<object> { "Hello”", "goodbye", 'x', true };
            int sum = 0;
            foreach (object num in myList)
            {
                string message = "There is no message to print.";
                if (num is int)
                {
                    sum += (int)num;
                }
                else if (num is string)
                {
                    string message = (string)num;
                }
            }
            System.Console.WriteLine("The sum of all numbers in");
        }
    }
}
