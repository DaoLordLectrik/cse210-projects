using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int _Points) : base(name, description, _Points)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] \"{_Name}\" \"{_Description}\"");
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal: \"{_Name}\". Points awarded: {_Points}");
    }
}
