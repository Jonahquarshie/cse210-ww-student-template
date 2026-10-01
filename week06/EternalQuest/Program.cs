using System;

class Program
{
    /* 
      CREATIVITY & EXCEEDING REQUIREMENTS REPORT:
      1. Leveling Up Engine: Added a programmatic leveling system calculated directly 
         from the player's core score. Every 1000 points dynamically updates 
         the player's "Quest Adventurer Tier Level" on the profile screen.
      2. Negative Goals Concept: Added a standalone goal subclass called 'NegativeGoal' 
         built exclusively to break bad behaviors (e.g., spending too much money or 
         skipping workouts). Logging this type of goal subtracts an active penalty from the total score.
    */
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
