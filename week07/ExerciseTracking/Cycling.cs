using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(string date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        // Method Overriding
        public override double GetDistance() => (_speed * GetMinutes()) / 60;

        public override double GetSpeed() => _speed;

        public override double GetPace() => 60 / _speed;
    }
}
