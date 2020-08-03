using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            foreach (object item in myList)
            {
                Console.WriteLine(item);
            }
            int sum = 0;
            foreach (object item in myList)
            {
                if (item is int)
                {
                    sum = sum + (int)item;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
