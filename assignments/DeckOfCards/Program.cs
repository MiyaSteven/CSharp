using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck firstDeck = new Deck();
            firstDeck.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Console.Write("{0, -19}", firstDeck.DealCards());
                if ((i + 1) % 4 == 0)
                    Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
