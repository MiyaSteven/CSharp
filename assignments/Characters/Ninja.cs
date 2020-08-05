using System;
using System.Collections.Generic;

namespace Characters
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name) { }

        public Ninja(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp) { }

        public int Steal(Ninja target)
        {
            int drain = 5;
            target.health -= drain;
            health += drain;
            Console.WriteLine($"{Name} stole 5 hp from {target.Name} and healed to {health} hp");
            return target.health;
        }

        public override int Attack(Human target)
        {
            int dmg = Dexterity * 5;
            Random rand = new Random();
            int luck = rand.Next(0, 10);
            if (luck == 0)
            {
                dmg = dmg + 10;
            }
            if (luck == 1)
            {
                dmg = dmg + 10;
            }
            else
            {
            }
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }
}