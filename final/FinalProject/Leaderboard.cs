using System;
using System.Collections.Generic;

public class Leaderboard
{
    private Dictionary<string, int> fastestTimes; // Dictionary to store fastest times for each game mode

    public Leaderboard()
    {
        fastestTimes = new Dictionary<string, int>();
    }

    public void UpdateLeaderboard(string gameMode, int time)
    {
        if (fastestTimes.ContainsKey(gameMode))
        {
            // If the current time is faster than the previous fastest time, update it
            if (time < fastestTimes[gameMode])
            {
                fastestTimes[gameMode] = time;
            }
        }
        else
        {
            // If this is the first time recorded for the game mode, add it to the leaderboard
            fastestTimes[gameMode] = time;
        }
    }

    public void DisplayLeaderboard()
    {
        Console.WriteLine("Leaderboard:");

        foreach (var kvp in fastestTimes)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} seconds");
        }
    }
}
