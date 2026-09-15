using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt inspired or peaceful this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {}

    protected override void ExecuteActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("\nList as many items as you can against the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> userItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        // Standard Console.ReadLine will block execution, so we monitor the time
        while (DateTime.Now < endTime)
        {
            // Simple approach for console inputs within time frames
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                userItems.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {userItems.Count} items!");
    }
}
