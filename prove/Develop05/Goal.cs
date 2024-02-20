using System;

abstract class Goal
{
    public string _Name { get; set; }
    public string _Description { get; set; }
    public int _Points { get; set; }
    public bool _Completed { get; set; }

    public Goal(string name, string description, int Points)
    {
        _Name = name;
        _Description = description;
        _Points = Points;
        _Completed = false;
    }

    public abstract void Display();
    public abstract void RecordEvent();
}
