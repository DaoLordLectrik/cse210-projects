using System;

class ChecklistGoal : Goal
{
    public int _target { get; set; }
    public int _amountCompleted { get; set; }

    public ChecklistGoal(string name, string description, int _Points, int target) : base(name, description, _Points)
    {
        _target = target;
        _amountCompleted = 0;
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] \"{_Name}\" \"{_Description}\" {_amountCompleted}/{_target}");
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Event recorded for checklist goal: \"{_Name}\". Points awarded: {_Points}");
        if (_amountCompleted == _target)
        {
            _Completed = true;
            Console.WriteLine($"Checklist goal \"{_Name}\" completed!");
        }
    }
}
