using System;
using System.Collections.Generic;

namespace Characters
{
    public class Samurai : Human
    {
        public Samurai(string name) : base(name) { }

        public Samurai(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp) { }

        public int Meditate(Samurai target)
        {
            target.health = 100;
            Console.WriteLine($"{Name} healed back to 100 health");
            return target.health;
        }

        // Build Attack method
        public override int Attack(Human target)
        {
            int dmg = Strength * 3;
            if (target.health < 50)
            {
                dmg = target.health;
            }
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }
}