using System;
using System.Collections.Generic;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word:");
            string originalWord = Console.ReadLine();
            Console.WriteLine("Your word in reverse is {0}", ReverseString(originalWord));
            Console.WriteLine("Your word with vowels as '?' is {0}", originalWord.Replace('a', '?').Replace('e', '?').Replace('i', '?').Replace('o', '?').Replace('u', '?'));
            Console.WriteLine("Your word is {0}a palindrome", (ReverseString(originalWord.ToLower())==originalWord.ToLower())?"":"not ");
        }

        static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
