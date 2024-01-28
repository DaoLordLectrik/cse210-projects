using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");

        // Create a sample scripture
        var scripture = new Scripture("John 14:26", "But the Comforter, which is the Holy Ghost, whom the Father will send in my cname, he shall teach you all things, and bring all things to your remembrance, whatsoever I have said unto you.");

        // Memorization loop
        while (!scripture.IsCompletelyHidden)
        {
            // Display the scripture
            GetDisplayText(scripture);

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            // Hide a few random words
            scripture.HideRandomWords();
        }

        Console.WriteLine("\nProgram ended. Good job on memorizing the scripture!");
    }

    static void GetDisplayText(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine($"{scripture.Reference} {scripture.DisplayText}");
    }
}

class Scripture
{
    private readonly Reference reference;
    private readonly List<Word> words;

    public bool IsCompletelyHidden => words.All(word => word._isHidden);

    public string Reference => reference.ToString();

    public string DisplayText
    {
        get
        {
            return string.Join(" ", words.Select(word => word._isHidden ? "_____" : word._text));
        }
    }

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = CreateWordList(scriptureText);
    }

    private List<Word> CreateWordList(string scriptureText)
    {
        var words = new List<Word>();
        string[] wordArray = scriptureText.Split(' ');

        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }

        return words;
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        // hide three words at a time
        int numberToHide = Math.Min(3, words.Count(word => !word._isHidden));

        // Select random words to hide
        var wordsIndices = Enumerable.Range(0, words.Count).Where(i => !words[i]._isHidden).ToList();
        var indicesToHide = wordsIndices.OrderBy(x => random.Next()).Take(numberToHide);

        // Hide selected words
        foreach (var index in indicesToHide)
        {
            words[index].Hide();
        }
    }
}

class Reference
{
    public string _book { get; }
    public int _chapter { get; }
    public int _verse { get; }
    public int _endverse { get; }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');

        if (parts.Length == 3)
        {
            _book = parts[0];
            _chapter = int.Parse(parts[1].Split(':')[0]);
            string[] verses = parts[2].Split('-');
            _verse = int.Parse(verses[0]);
            _endverse = verses.Length > 1 ? int.Parse(verses[1]) : _verse;
        }
        else if (parts.Length == 2)
        {
            _book = parts[0];
            string[] verses = parts[1].Split(':');
            _chapter = int.Parse(verses[0]);
            string[] verseNumbers = verses[1].Split('-');
            _verse = int.Parse(verseNumbers[0]);
            _endverse = verseNumbers.Length > 1 ? int.Parse(verseNumbers[1]) : _verse;
        }
    }

    public override string ToString()
    {
        if (!string.IsNullOrEmpty(_book))
        {
            return $"{_book} {_chapter}:{_verse}";
            //return $"{_book} {_chapter}:{_verse}-{_endverse}";
        }
        else
        {
            return $"{_chapter}:{_verse}-{_endverse}";
        }
    }
}


class Word
{
    public string _text { get; }
    public bool _isHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }
}
