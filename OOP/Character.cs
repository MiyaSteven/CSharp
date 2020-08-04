using System;

namespace OOP
{
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        // public DateTime Birthday { get; set; }
        // public int Age {
        //     get {
        //         return (DateTime.Today - Birthday).Days / 365;
        //     }
        // }
        public Character()
        {
            Name = "Ninja";
            // Birthday = DateTime.Now;
            Health = 100;
            Strength = 3;
            Dexterity = 3;
            Intelligence = 3;
        }
    }
}
