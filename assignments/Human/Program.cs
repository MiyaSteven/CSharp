using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            // Person myPerson = new Person(1);

            Person newPerson = new Person();
            Console.WriteLine($"The World is holding {newPerson.PeopleCount} people");
            Console.WriteLine($"The Person has a name of {newPerson.Name}");
            Console.WriteLine($"They have {newPerson.BirthRate} children");
            Console.WriteLine($"They have {newPerson.Health} Health");
            Console.WriteLine($"They have total of {newPerson.Skills} skill points");
        }
    }
    public class Person
    {
        public int PeopleCount;
        public string Name;
        public double BirthRate;
        public int Health;
        public int Skills;

        public Person(int val, string name, int birthrate, string noise, int health, int skills)
        {
            PeopleCount = val;
            Name = name;
            BirthRate = birthrate;
            Health = health;
            Skills = skills;
        }
        public Person()
        {
            PeopleCount = 2;
            Name = "NinjaMon";
            BirthRate = 2;
            Health = 100;
            Skills = 5;
        }
        public void Attack(Person target)
        {
            int dmg = (int)(Skills);
            target.Health -= dmg;
            System.Console.WriteLine($"{Name} attacks {target.Name} for {dmg} damage!");
        }
        // public void MakeNoise(string noise)
        // {
        //     Console.WriteLine(noise);
        // }
        // public void MakeNoise()
        // {
        //     Console.WriteLine("LOUD NOISES");
        // }
    }
}
