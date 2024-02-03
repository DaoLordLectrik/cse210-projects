using System;
using System.Threading;

// Base class for all mindfulness activities
public abstract class MindfulnessActivity
{
    private string activity;
    protected int ShowCountDown;

    public MindfulnessActivity(string name, int duration)
    {
        activity = name;
        ShowCountDown = duration;
    }

    // Common starting message for all activities
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Get ready for {activity} Activity!");
        Console.WriteLine($"Duration: {ShowCountDown} seconds");
        PauseForSeconds(3); // Pause for a few seconds before starting
        Console.WriteLine($"");
    }

    // Common ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! You have completed {activity} activity!");
        Console.WriteLine($"Total time: {ShowCountDown} seconds");
        PauseForSeconds(3); // Pause for a few seconds before finishing
        Console.WriteLine($"");
    }

    // Helper method to pause for a specified number of seconds
    protected void PauseForSeconds(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Abstract method to be implemented by each specific activity
    public abstract void run();
}
