using System;
using System.Collections.Generic;

namespace FitnessCenterApp
{
    // =========================================================================
    // BASE CLASS: Activity
    // =========================================================================
    public abstract class Activity
    {
        // Encapsulation: Private member variables
        private string _date;
        private int _minutes;

        // Constructor
        public Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Getters for private fields to be used by derived classes or methods
        public string GetDate() => _date;
        public int GetMinutes() => _minutes;

        // Abstract methods: Declared but not implemented here. 
        // Force derived classes to provide calculations.
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // GetSummary method shared by all classes
        public virtual string GetSummary()
        {
            // Formats: Date Activity (X min): Distance X miles, Speed X mph, Pace X min per mile
            return $"{GetDate()} {GetType().Name} ({GetMinutes()} min): " +
                   $"Distance {GetDistance():F1} miles, " +
                   $"Speed {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }

    // =========================================================================
    // DERIVED CLASS: Running
    // =========================================================================
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(string date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;

        public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

        public override double GetPace() => GetMinutes() / GetDistance();
    }

    // =========================================================================
    // DERIVED CLASS: Cycling
    // =========================================================================
    public class Cycling : Activity
    {
        private double _speed; // in mph

        public Cycling(string date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance() => (GetSpeed() * GetMinutes()) / 60;

        public override double GetSpeed() => _speed;

        public override double GetPace() => 60 / GetSpeed();
    }

    // =========================================================================
    // DERIVED CLASS: Swimming
    // =========================================================================
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(string date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        // Distance (miles) = swimming laps * 50 / 1000 * 0.62
        public override double GetDistance() => _laps * 50.0 / 1000.0 * 0.62;

        public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

        public override double GetPace() => GetMinutes() / GetDistance();
    }

    // =========================================================================
    // MAIN PROGRAM EXECUTION (Program.cs)
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store all activities (Polymorphism in action)
            List<Activity> activities = new List<Activity>();

            // Create at least one activity of each type
            Running runningActivity = new Running("01 Oct 2026", 30, 3.0);
            Cycling cyclingActivity = new Cycling("02 Oct 2026", 45, 15.0);
            Swimming swimmingActivity = new Swimming("03 Oct 2026", 20, 40);

            // Add activities to the single collection list
            activities.Add(runningActivity);
            activities.Add(cyclingActivity);
            activities.Add(swimmingActivity);

            // Iterate through the list, call GetSummary polymorphism, and display results
            Console.WriteLine("--- Fitness Center Exercise Summary ---");
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
