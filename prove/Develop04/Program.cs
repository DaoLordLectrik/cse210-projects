using System;

// Main program
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Mindfulness App!");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                Console.WriteLine("Enter duration in seconds:");
                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                {
                    MindfulnessActivity activity = choice switch
                    {
                        1 => new BreathingActivity(duration),
                        2 => new ReflectionActivity(duration),
                        3 => new ListingActivity(duration),
                        _ => null
                    };

                    if (activity != null)
                    {
                        activity.run();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a positive integer.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
