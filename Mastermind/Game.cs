using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace Mastermind
{
    internal class Game
    {
        //Length of generated random number
        private const int maxNumberLength = 4;
        //No of attempts a user can try to guess the number
        private const int noOfAttempts = 10;

        public static GuessStatus GetOrSetInputGuess { get; set; }

        //Holds the randonly generated number
        private static string? RandomNumber { get; set; }

        public static int NoOfTries { get; set; }

        private static void InitializeGame()
        {
            RandomNumber = string.Empty;
            NoOfTries = 0;
        }

        public static void DisplayGameRulesAndGenerateRandomNumber()
        {
            Console.WriteLine("Welcome to Mastermind! You have 10 attempts to guess a randomly generated 4 digit number between 1 & 6.");
            Console.WriteLine("A '+' character will be printed for every correct guess of a number at correct position.");
            Console.WriteLine("A '-' character will be printed for every correct guess of a number at an incorrect position.");
            Console.WriteLine("Nothing will be printed for the incorrectly guessed digit.");
            Console.WriteLine("All the best and have fun playing the game!");
            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine("Press 'N' or enter key to start a new game and 'Q' to quit the game.");

            InitializeGame();    
            GenerateRandomNumber();
        }

        public static void GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNext = random.Next(1, 6);
            //Check added so that the random number doesn't contain a number twice.
            if (RandomNumber.Contains(randomNext.ToString()))
                GenerateRandomNumber();
            else
               RandomNumber += randomNext;
            if (RandomNumber.Length == maxNumberLength)
                return;
            else
                GenerateRandomNumber();
        }
        
        public static string CheckUserAnswer(string input)
        {
            GetOrSetInputGuess = GuessStatus.InvalidInput;
            if (string.IsNullOrEmpty(input))
                return "Please make a guess before submitting your answer.";
            else if (input.Length != maxNumberLength)
                return $"Please enter a {maxNumberLength} digit number.";
            else if (!Int32.TryParse(input, out int inputToInteger))
                return "You accidentally entered a letter in your guess.Please try again";
            else if (RandomNumber == input)
            {
                GetOrSetInputGuess = GuessStatus.CorrectGuess;
                return "Congratulations, your guess is correct!";
            }
            else
            {
                NoOfTries++;
                if (NoOfTries == noOfAttempts)
                    return $"Your {noOfAttempts} attempts of guessing the correct answer are over.";
                GetOrSetInputGuess = GuessStatus.InvalidGuess;
                return DisplayUserGuessWithHints(input);
            }
        }

        //Displays '+' or '-' based on how user's guess matches with the random number
        private static string DisplayUserGuessWithHints(string input)
        {
            string hint = string.Empty;
            for (int ch = 0; ch < input.Length; ch++)
            {
                if (RandomNumber.Contains(input[ch]) && RandomNumber.Substring(ch, 1) == input[ch].ToString())
                    hint += "+";
                else if (RandomNumber.Contains(input[ch]) && RandomNumber.Substring(ch, 1) != input[ch].ToString())
                    hint += "-";
                else if (!RandomNumber.Contains(input[ch]))
                    hint += " ";
            }
            return hint;
        }
        public enum GuessStatus
        {
            InvalidInput = 0,
            InvalidGuess = 1,
            CorrectGuess = 2
        }
    }
}
