using System;
using System.Diagnostics;

public class FastTrail : IGhostWriterGame
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public void StartGame()
    {
        Console.WriteLine("Welcome to Fast Trail!");
        Console.WriteLine("Type the alphabets from A to Z");

        string _expectedInput = "abcdefghijklmnopqrstuvwxyz";
        string _userInput = GetUserInput();

        if (_userInput.ToLower() == _expectedInput)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            GetUserInput(); // Wait for user to finish typing
            stopwatch.Stop();
            TimeSpan duration = stopwatch.Elapsed;
            Console.WriteLine($"Time spent: {duration}");
        }
        else
        {
            Console.WriteLine("Sorry, incorrect input.");
        }
    }

    private string GetUserInput()
    {
        return Console.ReadLine();
    }
}
