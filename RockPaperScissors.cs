using System;
using System.Collections.Generic;
using System.IO;
namespace RockPaperScissors
{
    class Program
    {
        struct Score
        {
            public Score(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
            public string name;
            public int score;
        }
        static void Main(string[] args)
        {
            // Read scoreboard into list ////
            List<Score> scores = new List<Score>();
            string[] scoreList = File.ReadAllLines("scoreboard.txt");
            foreach (string score in scoreList)
            {
                scores.Add(new Score(score.Split("|")[0], int.Parse(score.Split("|")[1])));
            }
            Console.WriteLine("Current Score Table:");
            foreach(Score score in scores)
            {
                Console.WriteLine(score.name + " - " + score.score);
            }
            Console.ReadLine();
            /////////////////////////////////
            Console.Clear();
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine().Replace("|", ""); // SANITISE!
            int pScore = 0, cScore = 0;
            Console.WriteLine("Press any key to start (type \"scores\" to see scoreboard and exit)");
            while (Console.ReadLine() != "scores")
            {
                Console.Clear();
                Console.WriteLine("{2}   {0}|{1}     CPU", pScore, cScore, playerName);
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
                    AddScore(result ? playerName : "CPU", scores);
                }
            }
            RefreshList(scores, "scoreboard.txt");
        }

        static void AddScore(string name, List<Score> scores)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                if(scores[i].name == name)
                {
                    scores[i] = new Score(name, scores[i].score + 1);
                }
            }

            
        }

        static void RefreshList(List<Score> scores, string path)
        {
            List<Score> sortedScores = scores.OrderByDescending(myvalue => myvalue.score).ToList();
            string[] scoresList = new string[sortedScores.Count];
            for (int i = 0;i<sortedScores.Count;i++)
            {
                scoresList[i] = sortedScores[i].name + "|" + sortedScores[i].score;
            }
            File.WriteAllLines(path, scoresList);
        }


    }
}
