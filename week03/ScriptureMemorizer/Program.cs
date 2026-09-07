using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine();
        Console.WriteLine("Choose a scripture:");
        Console.WriteLine("1. Proverbs 3:5-6");
        Console.WriteLine("2. Philippians 4:13");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        Reference reference;
        string text;

        if (choice == "2")
        {
            reference = new Reference("Philippians", 4, 13);
            text = "I can do all things through Christ which strengtheneth me";
        }
        else
        {
            reference = new Reference("Proverbs", 3, 5, 6);
            text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        }

        Scripture scripture = new Scripture(reference, text);

        // Creativity: I added a scripture selection menu so users can
        // choose between multiple scriptures instead of memorizing only one.

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("All words are now hidden. Great job!");
    }
}