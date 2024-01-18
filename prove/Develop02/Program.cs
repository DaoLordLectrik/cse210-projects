using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string _promptText { get; set; }
    public string _entryText { get; set; }
    public string _date { get; set; }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry()
    {
        Console.WriteLine("Select a prompt for today's entry:");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine(randomPrompt);

        Console.Write("Your response: ");
        string entry = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry
        {
            _promptText = randomPrompt,
            _entryText = entry,
            _date = currentDate
        };

        entries.Add(newEntry);
        Console.WriteLine("Entry recorded successfully!");
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry._date} || Prompt: {entry._promptText}\nResponse: {entry._entryText}\n");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string fileName = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }

        Console.WriteLine($"Journal saved to {fileName} successfully!");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            entries.Clear();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] entryData = sr.ReadLine().Split('|');
                    Entry loadedEntry = new Entry
                    {
                        _date = entryData[0],
                        _promptText = entryData[1],
                        _entryText = entryData[2]
                    };
                    entries.Add(loadedEntry);
                }
            }

            Console.WriteLine($"Journal loaded from {fileName} successfully!");
        }
        else
        {
            Console.WriteLine($"File {fileName} not found.");
        }
    }

    private string GetRandomPrompt()
    {
        List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

        public void DisplayTodaysPrompt()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd");

    var todayEntries = entries.Where(entry => entry._date == today);

    if (todayEntries.Any())
        {
            Console.WriteLine($"Prompts for today:");

            foreach (var entry in todayEntries)
            {
                Console.WriteLine($"*{entry._promptText}");
            }
        }
    else
        {
            Console.WriteLine("No entry recorded for today. Write a new entry to see today's prompts!");
        }
    }

}


class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Display Today's Prompt");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    myJournal.AddEntry();
                    break;
                case 2:
                    myJournal.DisplayAll();
                    break;
                case 3:
                    myJournal.SaveToFile();
                    break;
                case 4:
                    myJournal.LoadFromFile();
                    break;
                case 5:
                    myJournal.DisplayTodaysPrompt();
                    break;
                case 6:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}