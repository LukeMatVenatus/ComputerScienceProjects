using System;
namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int pScore = 0, cScore = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("PLAYER   {0}|{1}     CPU", pScore, cScore);
                Console.WriteLine("Please enter Rock, Paper or Scissors:");
                string pChoiceStr = Console.ReadLine().ToLower();
                int pChoice = pChoiceStr == "rock" ? 1 : (pChoiceStr == "paper" ? 2 : 3);
                int cChoice = new Random().Next(1, 3);
                Console.WriteLine("The Computer chose " + (cChoice == 1 ? "rock" : (cChoice == 2 ? "paper" : "scissors")));
                if (pChoice == cChoice)
                {
                    Console.WriteLine("It's a draw!");
                    Console.ReadLine();
                }
                else
                {

                    bool result = (pChoice == 2 ? (cChoice == pChoice - 1 ? true : false) : (pChoice == 1 ? (cChoice == 3 ? true : false) : (cChoice == 1 ? false : true)));
                    Console.WriteLine((result ? "You" : "Computer") + " won!");
                    pScore += result ? 1 : 0;
                    cScore += !result ? 1 : 0;
                    Console.ReadLine();
                }
            }
            
        }


    }
}
