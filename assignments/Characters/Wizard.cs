using System;
using System.Collections.Generic;

namespace Characters
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name) { }

        public Wizard(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp) { }

        public int Heal(Wizard target)
        {
            int healAmount = Intelligence * 10;
            target.health += healAmount;
            System.Console.WriteLine($"{Name} healed Human {target.Name} for {healAmount} Health!");
            return target.health;
        }
        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.health -= dmg;
            health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }
}