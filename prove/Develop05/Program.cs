using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            Console.WriteLine("Welcome to Goal Tracker!");
            Console.WriteLine($"Current points: {goalManager.Get_score()}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals to file");
            Console.WriteLine("4. Load goals from file");
            Console.WriteLine("5. Record event for a goal");
            Console.WriteLine("6. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.ListGoals();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Get_score()
    {
        return _score;
    }

    public void CreateGoal()
    {
        Console.WriteLine("");
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of points associated with this goal: ");
        int _Points;
        Console.WriteLine("");
        while (!int.TryParse(Console.ReadLine(), out _Points))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            Console.Write("Enter the amount of points associated with this goal: ");
        }

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, _Points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, _Points));
                break;
            case "3":
                Console.Write("Enter the total number of times to complete the event: ");
                int totalTimes;
                while (!int.TryParse(Console.ReadLine(), out totalTimes))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("Enter the total number of times to complete the event: ");
                }
                _goals.Add(new ChecklistGoal(name, description, _Points, totalTimes));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"[{i + 1}] ");
            _goals[i].Display();
            Console.WriteLine("");
        }
    }

class ChecklistGoal : Goal
{
    public int TotalTimes { get; set; }
    public int TimesCompleted { get; set; }
    public int CurrentRecorded { get; set; } // New property to store the current recorded events

    public ChecklistGoal(string name, string description, int _Points, int totalTimes) : base(name, description, _Points)
    {
        TotalTimes = totalTimes;
        TimesCompleted = 0;
        CurrentRecorded = 0; // Start the current recorded events to 0
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] \"{_Name}\" \"{_Description}\" {TimesCompleted}/{TotalTimes}");
    }

    public override void RecordEvent()
    {
        TimesCompleted++;
        CurrentRecorded++; // Increase the current recorded events
        Console.WriteLine($"Event recorded for checklist goal: \"{_Name}\". Points awarded: {_Points}");
        if (TimesCompleted == TotalTimes)
        {
            _Completed = true;
            Console.WriteLine($"Checklist goal \"{_Name}\" completed!");
            Console.WriteLine("");
        }
    }
}
public void SaveGoals()
{
    Console.Write("Enter the filename to save goals: ");
    string filename = Console.ReadLine();

    using (StreamWriter writer = new StreamWriter(filename))
    {
        foreach (Goal goal in _goals)
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                writer.WriteLine($"ChecklistGoal: {checklistGoal._Name}, {checklistGoal._Description}, {checklistGoal._Points}, {checklistGoal.TimesCompleted}, {checklistGoal.TotalTimes}, {checklistGoal.CurrentRecorded}");
            }
            else
            {
                writer.WriteLine($"{goal.GetType().Name}: {goal._Name}, {goal._Description}, {goal._Points}, {goal._Completed}");
            }
        }
        writer.WriteLine($"CurrentPoints: {_score}");
    }

    Console.WriteLine($"Goals saved to {filename} successfully!");
    Console.WriteLine("");
}

public void LoadGoals()
{
    Console.Write("Enter the filename to load goals: ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found.");
        return;
    }

    _goals.Clear(); // Clear existing goals before loading new ones

    using (StreamReader reader = new StreamReader(filename))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.StartsWith("CurrentPoints:"))
            {
                _score = int.Parse(line.Split(':')[1].Trim());
            }
            else
            {
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0].Trim(), data[1].Trim(), int.Parse(data[2].Trim())) { _Completed = bool.Parse(data[3].Trim()) });
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0].Trim(), data[1].Trim(), int.Parse(data[2].Trim())) { _Completed = bool.Parse(data[3].Trim()) });
                        break;
                    case "ChecklistGoal":
                        int currentRecorded = 0;
                        if (data.Length > 5) // Check if CurrentRecorded is present in the file
                        {
                            currentRecorded = int.Parse(data[5].Trim());
                        }
                        _goals.Add(new ChecklistGoal(data[0].Trim(), data[1].Trim(), int.Parse(data[2].Trim()), int.Parse(data[4].Trim())) { _Completed = bool.Parse(data[3].Trim()), CurrentRecorded = currentRecorded });
                        break;
                    default:
                        Console.WriteLine("Unknown goal type in file.");
                        break;
                }
            }
        }
    }

    Console.WriteLine($"Goals loaded from {filename} successfully!");
}



    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Please create a goal first.");
            return;
        }

        Console.WriteLine("Select a goal to record an event:");
        ListGoals();

        Console.Write("Enter the index of the goal: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        Goal selectedGoal = _goals[index - 1];
        selectedGoal.RecordEvent();

        _score += selectedGoal._Points;
    }
}