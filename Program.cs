using System;
using System.Collections.Generic;

namespace CardGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cardsDrawn = new List<string>();
            for (int i = 0; i < 53; i++) // Do the whole thing 53 times
            {
                if(cardsDrawn.Count > 52) // Check if we have drawn the whole deck
                {
                    Console.WriteLine("No more cards!");
                }
                else // If not, draw another card
                {
                    string result = DealCard();
                    while (cardsDrawn.Contains(result)) // Check if our generated card already exists, if not generate another one
                    {
                        result = DealCard();
                    }
                    cardsDrawn.Add(result); // Add this new card onto the list of cards drawn
                    Console.WriteLine(result);
                }
                
            }
        }

        static string DealCard()
        {
            string[] possibilities = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Ace", "Jack", "Queen", "King", "Hearts", "Spades", "Clubs", "Diamonds" };
            return possibilities[new Random().Next(0, 12)] + " of " + possibilities[new Random().Next(13, 15)];

        }
    }
}
