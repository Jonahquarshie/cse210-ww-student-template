using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Functionality: All activity instances reside in the exact same list
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running("01 Oct 2026", 30, 3.0));
            activities.Add(new Cycling("02 Oct 2026", 45, 15.0));
            activities.Add(new Swimming("03 Oct 2026", 30, 40));

            // Functionality: Dynamic runtime dispatch outputs correct polymorphic values
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
