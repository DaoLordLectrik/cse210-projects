using System;

class Program
{
    static void Main(string[] args)
    {
        // IGhostWriterGame ghostTrail = new GhostTrail();
        IGhostWriterGame memoryTrail = new MemoryTrail();
        IGhostWriterGame fastTrail = new FastTrail();
        Leaderboard leaderboard = new Leaderboard();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Select a game mode:");
            Console.WriteLine("1. Ghost Trail");
            Console.WriteLine("2. Memory Trail");
            Console.WriteLine("3. Fast Trail");
            Console.WriteLine("4. Leaderboard");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // ghostTrail.StartGame();
                    break;
                case "2":
                    memoryTrail.StartGame();
                    break;
                case "3":
                    fastTrail.StartGame();
                    break;
                case "4":
                    leaderboard.DisplayLeaderboard();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}
