using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * SHOWING CREATIVITY AND EXCEEDING REQUIREMENTS:
             * 1. Added a Dynamic Question Pool tracking mechanism in ReflectionActivity.cs to prevent questions 
             *    from repeating until all unique options have been exhausted in a single session block.
             * 2. Added an extra Session Statistics Log right here in Program.cs that acts as a real-time tracking dashboard 
             *    to calculate total combined time and active execution statistics across the session.
             */

            int breathingCount = 0;
            int reflectionCount = 0;
            int listingCount = 0;
            int totalSecondsSpent = 0;

            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        MINDFULNESS PROGRAM             ");
                Console.WriteLine("========================================");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflection activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. View Current Session Activity Logs (Extra Feature)");
                Console.WriteLine("  5. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Activity breathing = new BreathingActivity();
                        breathing.Run();
                        breathingCount++;
                        totalSecondsSpent += breathing.Duration;
                        break;
                    case "2":
                        Activity reflection = new ReflectionActivity();
                        reflection.Run();
                        reflectionCount++;
                        totalSecondsSpent += reflection.Duration;
                        break;
                    case "3":
                        Activity listing = new ListingActivity();
                        listing.Run();
                        listingCount++;
                        totalSecondsSpent += listing.Duration;
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=== Current Session Dashboard ===");
                        Console.WriteLine($"Breathing Sessions Completed:   {breathingCount}");
                        Console.WriteLine($"Reflection Sessions Completed:  {reflectionCount}");
                        Console.WriteLine($"Listing Sessions Completed:     {listingCount}");
                        Console.WriteLine($"Total Mindful Time Accumulated: {totalSecondsSpent} seconds");
                        Console.WriteLine("\nPress Enter to return to the main menu...");
                        Console.ReadLine();
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
