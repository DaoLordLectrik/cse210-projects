// Listing activity class
public class ListingActivity : MindfulnessActivity
{
    private readonly List<string> _prompts = new List<string>();
    private readonly string[] _allPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing", duration) { }

    public override void run()
    {
        DisplayStartingMessage();

        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Press Enter to begin.");
        Console.ReadLine(); // Wait for the user to press Enter before starting the listing activity

        Console.WriteLine($"Duration: {ShowCountDown} seconds");

        int remainingDuration = ShowCountDown;

        while (remainingDuration > 0)
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);

            Console.Write("Your response: ");
            string userResponse = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userResponse))
            {
                Console.WriteLine("Response cannot be empty. Please enter a response.");
                continue;
            }

            remainingDuration -= 5;
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // Ensure that all prompts have been used before repeating
        if (_prompts.Count == _allPrompts.Length)
        {
            _prompts.Clear(); // Reset used prompts if all have been used
        }

        string randomPrompt;
        do
        {
            randomPrompt = _allPrompts[new Random().Next(_allPrompts.Length)]; // Select a random prompt
        } while (_prompts.Contains(randomPrompt));

        _prompts.Add(randomPrompt); // Mark the prompt as used
        return randomPrompt;
    }
}
