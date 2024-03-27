
using Mastermind;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Game.DisplayGameRulesAndGenerateRandomNumber();
        var keyInfo =  Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.N || keyInfo.Key == ConsoleKey.Enter)
            PlayGame(keyInfo);   
        else if (Console.ReadKey().Key == ConsoleKey.Q)
            Environment.Exit(0);
    }

    private static void PlayGame(ConsoleKeyInfo keyInfo)
    {
        Console.WriteLine("\nThe game starts, make a guess!");
        Console.WriteLine(Game.CheckUserAnswer(Console.ReadLine()));
        if (Game.GetOrSetInputGuess == Game.GuessStatus.CorrectGuess || Game.GetOrSetInputGuess == Game.GuessStatus.InvalidInput)
            KeepPlayingGame(keyInfo);
        else if (Game.GetOrSetInputGuess == Game.GuessStatus.InvalidGuess)
        {
            //Allow user to make 10 guesses
            for (int tries = 0; tries < Game.NoOfTries; tries++)
            {
               Console.WriteLine(Game.CheckUserAnswer(Console.ReadLine()));
            }
            KeepPlayingGame(keyInfo);
        }
    }

    private static void KeepPlayingGame(ConsoleKeyInfo keyInfo)
    {
        Game.DisplayGameRulesAndGenerateRandomNumber();
        keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.N || keyInfo.Key == ConsoleKey.Enter)
          PlayGame(keyInfo);
    }
    

  

   

    

  

    
}

