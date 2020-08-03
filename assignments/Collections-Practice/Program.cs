using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] nameArray = { "Tim", "Martin", "Nikki", "Sara" };
            bool[] boolArray = { true, false, true, false, true, false, true, false, true, false };

            List<string> iceCreamFlavor = new List<string> { "vanilla", "chocolate", "strawberry", "mint", "coffee" };
            System.Console.WriteLine(iceCreamFlavor.Count);
            iceCreamFlavor.RemoveAt(2);
            foreach (string flavor in iceCreamFlavor)
            {
                System.Console.WriteLine(flavor);
            }
            System.Console.WriteLine(iceCreamFlavor.Count);

            Dictionary<string, string> userInfoDict = new Dictionary<string, string>();
            Random rand = new Random();
            //Prints the next random value between 2 and 8
            Console.WriteLine("The random ice cream flavor is " + rand.Next(0, iceCreamFlavor.Count));
            foreach (string name in nameArray)
            {
                userInfoDict.Add(name, iceCreamFlavor[rand.Next(0, iceCreamFlavor.Count)]);
            };
            foreach (var entry in userInfoDict)
            {
                System.Console.WriteLine(entry.Key + " loves " + entry.Value);
            }
        }

    }
}
