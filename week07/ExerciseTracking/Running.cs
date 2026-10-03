using System;

namespace ExerciseTracking
{
    // Inheritance: Derived from the Activity base class
    public class Running : Activity
    {
        private double _distance;

        public Running(string date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        // Method Overriding
        public override double GetDistance() => _distance;

        public override double GetSpeed() => (_distance / GetMinutes()) * 60;

        public override double GetPace() => GetMinutes() / _distance;
    }
}
