using System;
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int start = 0;
            int end = 255;
            // loop from start to end including end
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("This is start to end " + i);
            }
            // loop from start to end excluding end
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
            //The execution section does not always have to use ++
            for (int k = 1; k < 6; k = k + 1)
            {
                Console.WriteLine("This is start to end without ++ " + k);
            }
            int j = 1;
            while (j < 6)
            {
                Console.WriteLine("This is start to end using while " + j);
                j = j + 1;
            }
            RandomValues();
        }
        public static void RandomValues()
        {
            Random rand = new Random();
            for (int val = 0; val < 10; val++)
            {
                //Prints the next random value between 2 and 8
                Console.WriteLine("These are 10 random values" + rand.Next(2, 8));
            }
        }
    }
}