using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private const int PointsPerLevel = 1000;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordGoalEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        int level = (_score / PointsPerLevel) + 1;
        if (level < 1) level = 1;

        Console.WriteLine($"\n=== Player Profile ===");
        Console.WriteLine($"Current Score: {_score} points");
        Console.WriteLine($"Current Tier: Level {level} Quest Adventurer");
        Console.WriteLine($"======================");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Bad Habit Goal (Negative Points)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        if (type == "4")
        {
            Console.Write("What is the penalty score for doing this habit? ");
            int points = int.Parse(Console.ReadLine());
            _goals.Add(new NegativeGoal(name, description, points));
            return;
        }

        Console.Write("What is the amount of points associated with this goal? ");
        int pointsValue = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, pointsValue));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, pointsValue));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, pointsValue, target, bonus));
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0) Console.WriteLine("(No goals created yet)");
        
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordGoalEvent()
    {
        ListGoalDetails();
        if (_goals.Count == 0) return;

        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earnedPoints = _goals[index].RecordEvent();
            _score += earnedPoints;

            if (earnedPoints > 0)
            {
                Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
            }
            else if (earnedPoints < 0)
            {
                Console.WriteLine($"Penalty! You lost {Math.Abs(earnedPoints)} points due to a bad habit slip.");
            }
            else
            {
                Console.WriteLine("This goal is already fully complete.");
            }
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            if (parts.Length < 2) continue;

            string type = parts[0];
            string[] goalData = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]), bool.Parse(goalData[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3]), int.Parse(goalData[4]), int.Parse(goalData[5])));
            }
            else if (type == "NegativeGoal")
            {
                _goals.Add(new NegativeGoal(goalData[0], goalData[1], int.Parse(goalData[2]))) ;
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
}
