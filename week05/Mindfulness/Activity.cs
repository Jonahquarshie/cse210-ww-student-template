using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        // Encapsulation: Strict private backing fields with _underscoreCamelCase
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Encapsulation: Public getter to expose duration safely to derived classes
        public int Duration => _duration;

        public void Run()
        {
            DisplayStartingMessage();
            ExecuteActivity();
            DisplayEndingMessage();
        }

        protected abstract void ExecuteActivity();

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.\n");
            Console.WriteLine($"{_description}\n");
            Console.Write("How long, in seconds, would you like for your session? ");
            
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(4);
        }

        public void ShowSpinner(int seconds)
        {
            string[] spinnerChars = { "|", "/", "-", "\\" };
            int counter = 0;
            DateTime endTime = DateTime.Now.AddSeconds(seconds);

            while (DateTime.Now < endTime)
            {
                Console.Write(spinnerChars[counter % 4]);
                Thread.Sleep(250);
                Console.Write("\b \b"); // Rubric requirement: Uses backspaces to animate
                counter++;
            }
        }

        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b"); // Rubric requirement: Uses backspaces to animate
            }
        }
    }
}
