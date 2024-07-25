

using System;
using System.Collections.Generic;
using System.IO;

// Abstract Goal class
abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract void Save(StreamWriter writer);
    public abstract void Load(StreamReader reader);
}

// SimpleGoal class
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
        }
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name}" : $"[ ] {Name}";
    }

    public override void Save(StreamWriter writer)
    {
        writer.WriteLine("SimpleGoal");
        writer.WriteLine(Name);
        writer.WriteLine(Points);
        writer.WriteLine(IsComplete);
    }

    public override void Load(StreamReader reader)
    {
        Name = reader.ReadLine();
        Points = int.Parse(reader.ReadLine());
        IsComplete = bool.Parse(reader.ReadLine());
    }
}

// GoalManager class
class GoalManager
{
    private List<Goal> goals;
    private int totalScore;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.RecordEvent();
            if (goal.IsComplete)
            {
                totalScore += goal.Points;
            }
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
            {
                goal.Save(writer);
            }
        }
    }

    public void LoadGoals(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            totalScore = int.Parse(reader.ReadLine());
            goals.Clear();
            string goalType;
            while ((goalType = reader.ReadLine()) != null)
            {
                Goal goal;
                if (goalType == "SimpleGoal")
                {
                    goal = new SimpleGoal("", 0);
                }
                else
                {
                    continue;
                }
                goal.Load(reader);
                goals.Add(goal);
            }
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }
}

// Main program class
class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    goalManager.ShowGoals();
                    break;
                case 4:
                    goalManager.ShowScore();
                    break;
                case 5:
                    SaveGoals();
                    break;
                case 6:
                    LoadGoals();
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = new SimpleGoal(name, points);
        goalManager.AddGoal(newGoal);
    }

    static void RecordEvent()
    {
        goalManager.ShowGoals();
        Console.Write("Enter the number of the goal you completed: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        goalManager.RecordEvent(goalIndex);
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        goalManager.SaveGoals(filename);
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        goalManager.LoadGoals(filename);
    }
}
