using System;

public class MemoryTrail : IGhostWriterGame
{
    private const int WordCount = 5;
    private const int MinWordLength = 4;
    private const int MaxWordLength = 10;

    public void StartGame()
    {
        Console.WriteLine("Welcome to Memory Trail!");
        Console.WriteLine("Enter 5 words. Separate each word with a space, each between 4 to 10 characters long.");

        string _input = GetUserInput();

        Console.WriteLine("Now, type the following words separated by spaces as fast as possible:");
        Console.WriteLine(_input.Replace(" ", " * "));

        string userInput = GetUserInput();

        string[] _originalWords = _input.Split(' ');
        string[] _typedWords = userInput.Split(' ');

        // Validate if typed words match original words
        bool isValid = true;
        for (int i = 0; i < WordCount; i++)
        {
            if (_originalWords[i] != _typedWords[i])
            {
                isValid = false;
                break;
            }
        }

        if (isValid)
        {
            int wpm = CalculateWPM(userInput);
            Console.WriteLine($"Your words per minute: {wpm}");
        }
        else
        {
            Console.WriteLine("Sorry, your typed words do not match.");
        }
    }

    private string GetUserInput()
    {
        return Console.ReadLine();
    }

    private int CalculateWPM(string text)
    {
        // Calculate words per minute (WPM)
        int _wordCount = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        const int SecondsPerMinute = 60;
        return _wordCount * SecondsPerMinute / 5; // 5 is assumed to be the average word length
    }
}
