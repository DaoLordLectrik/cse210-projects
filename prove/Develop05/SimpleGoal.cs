using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int _Points) : base(name, description, _Points)
    {
    }

    public override void Display()
    {
        string completionStatus = _Completed ? "x" : " ";
        Console.WriteLine($"[{completionStatus}] \"{_Name}\" \"{_Description}\"");
    }

    public override void RecordEvent()
    {
        _Completed = true;
        Console.WriteLine($"Event recorded for simple goal: \"{_Name}\". Points awarded: {_Points}");
    }
}
