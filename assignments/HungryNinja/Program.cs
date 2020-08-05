using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Buffet printBuffet = new Buffet();
            Ninja person = new Ninja();
            System.Console.WriteLine(person);
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string Name, int Calories, bool IsSpicy, bool IsSweet)
        {
            this.Name = Name;
            this.Calories = Calories;
            this.IsSpicy = IsSpicy;
            this.IsSweet = IsSweet;
        }
    }
    class Buffet
    {
        public List<Food> Menu;

        public Buffet()
        {
            List<Food> Menu = new List<Food>()
            {
                new Food("Food", 500, false, false),
                new Food("Food1", 600, false, false),
                new Food("Food2", 700, false, false),
                new Food("Food3", 800, true, false),
                new Food("Food4", 900, false, true),
                new Food("Food5", 1000, true, true),
                new Food("Food6", 350, false, false),
                new Food("Food7", 450, false, false),
                new Food("Food8", 550, false, false)
            };
        }
        public void Serve()
        {
            Random rand = new Random();
            for (int val = 0; val < 3; val++)
            {
                Food item = Menu[rand.Next(0, Menu.Count)];
                System.Console.WriteLine(item);
            };
        }
    }
    class Ninja
    {

        public string name;
        private int calorieIntake;
        public bool isFull { get; set; }
        public List<Food> FoodHistory;

        public Ninja(string name = "1", int calorieIntake = 2500, bool isFull = true)
        {
            this.name = name;
            this.calorieIntake = calorieIntake;
            this.isFull = isFull;
        }
        // build out the Eat method
        public void Eat(Food item)
        {
        }
    }

}