using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
        public class Food
        {
            public string Name;
            public int Calories;
            // Foods can be Spicy and/or Sweet
            public bool IsSpicy;
            public bool IsSweet;
            // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        }
    }
}
