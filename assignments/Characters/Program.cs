using System;
using System.Collections.Generic;

namespace Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Human humanOne = new Human("Adam");
            Console.WriteLine(humanOne);
            Ninja ninjaOne = new Ninja("Naruto");
            Console.WriteLine(ninjaOne);
            Samurai samuraiOne = new Samurai("Jack");
            Console.WriteLine(samuraiOne);
            Wizard wizardOne = new Wizard("Harry");
            Console.WriteLine(wizardOne);
        }
    }
}
