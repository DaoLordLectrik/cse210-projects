using System;

// Breathing activity class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base("Breathing", duration) { }

    public override void run()
    {
        DisplayStartingMessage();

        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        Console.WriteLine($"Press Enter to begin. Duration: {ShowCountDown} seconds");
        Console.ReadLine(); // Wait for the user to press Enter before starting the breathing activity

        int breathingPhaseDuration = ShowCountDown / 2; // Divide by 2 for the breathing in and breathing out phases

        for (int i = 0; i < breathingPhaseDuration;)
        {
            Console.WriteLine("Breathe in...");
            PauseForSeconds(3); // Duration for "Breathe in..." phase
            i += 3;

            if (i < breathingPhaseDuration)
            {
                Console.WriteLine("Breathe out...");
                PauseForSeconds(3); // Duration for "Breathe out..." phase
                i += 3;
            }
        }


        DisplayEndingMessage();
    }

    // private void DisplayBreathingInstructions()
    // {
    //     Console.WriteLine("Follow these breathing instructions during the activity:");
    //     Console.WriteLine("1. Breathe in slowly through your nose for a count of 4.");
    //     Console.WriteLine("2. Hold your breath for a count of 4.");
    //     Console.WriteLine("3. Exhale slowly through your mouth for a count of 4.");
    //     Console.WriteLine("4. Pause for a count of 4 before repeating the cycle.");

    //     Console.WriteLine($"Duration: {ShowCountDown} seconds");
    //     Console.WriteLine("Press Enter to begin.");
    //     Console.ReadLine(); // Wait for the user to press Enter before starting the breathing activity
    // }

}
