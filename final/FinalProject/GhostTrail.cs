using System;
using System.Diagnostics;

public class GhostTrail : GameMode
{
    public override void Start()
    {
        Console.WriteLine("Enter a line of text with 10 words (each word must be between 4 to 10 characters long):");
        Console.WriteLine("Separate each word with a space");
        string _initialText = Console.ReadLine();
        string[] _initialWords = _initialText.Split(' ');

        if (_initialWords.Length != 10)
        {
            Console.WriteLine("You did not enter 10 words. Please try again.");
            return;
        }

        double startTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

        Console.WriteLine("Retype the line as fast as possible:");
        string retypeText = Console.ReadLine();

        double endTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
        double elapsedTime = endTime - startTime;

        string[] retypeWords = retypeText.Split(' ');

        if (retypeWords.Length != 10)
        {
            Console.WriteLine("You did not retype 10 words. Please try again.");
            return;
        }

        bool match = true;
        for (int i = 0; i < 10; i++)
        {
            if (_initialWords[i] != retypeWords[i])
            {
                match = false;
                break;
            }
        }

        if (!match)
        {
            Console.WriteLine("The words you typed do not match the initial text.");
            return;
        }

        double wpm = CalculateWordsPerMinute(_initialText, elapsedTime);
        Console.WriteLine($"Your WPM: {wpm}");
    }

    private double CalculateWordsPerMinute(string text, double elapsedTime)
    {
        int wordCount = text.Split(' ').Length;
        double minutes = elapsedTime / 60000; 
        return wordCount / minutes;
    }
}