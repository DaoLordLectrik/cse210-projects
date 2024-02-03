using System;

// Reflection activity class
public class ReflectionActivity : MindfulnessActivity
{
    private readonly string[] _prompts = {
        "--Think of a time when you stood up for someone else.",
        "--Think of a time when you did something really difficult.",
        "--Think of a time when you helped someone in need.",
        "--Think of a time when you did something truly selfless."
    };

    private readonly string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base("Reflection", duration) { }

    public override void run()
    {
        DisplayStartingMessage();

        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Console.WriteLine($"Press Enter to begin. Duration: {ShowCountDown} seconds");
        Console.ReadLine(); // Wait for the user to press Enter before starting the reflection activity

        int remainingDuration = ShowCountDown;

        // Ask one prompt question
        string prompt = _prompts[new Random().Next(_prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine(); // Wait for the user to press Enter before moving to the reflection questions

        Console.WriteLine("Reflect on the following questions for the remainder of the activity:");

        while (remainingDuration > 0) // Change the loop condition to continue until remainingDuration reaches 0
        {
            // Shuffle the reflection questions
            List<string> shuffledQuestions = reflectionQuestions.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (var question in shuffledQuestions)
            {
                Console.WriteLine(question);

                Console.WriteLine($"Remaining Duration: {remainingDuration} seconds");
                PauseForSeconds(5); // Pause for 5 seconds before displaying the next question

                remainingDuration -= 5; // Adjust the remaining duration

                if (remainingDuration <= 0) // Check if the remaining duration has reached or gone below 0
                    break; // Exit the loop if remaining duration is 0 or negative
            }
        }


        DisplayEndingMessage();
    }
}
