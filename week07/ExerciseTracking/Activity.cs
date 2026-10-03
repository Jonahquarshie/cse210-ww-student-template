using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        // Encapsulation: All member variables are private using _underscoreCamelCase
        private string _date;
        private int _minutes;

        public Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Getters to allow safe external or derived access
        public string GetDate() => _date;
        public int GetMinutes() => _minutes;

        // Polymorphism: Abstract methods to be overridden by subclasses
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Polymorphism: Virtual base method that builds summaries dynamically
        public virtual string GetSummary()
        {
            return $"{GetDate()} {GetType().Name} ({GetMinutes()} min) - " +
                   $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile";
        }
    }
}
