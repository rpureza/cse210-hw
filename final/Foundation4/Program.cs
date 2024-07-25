

using System;
using System.Collections.Generic;

// Base Activity class
abstract class Activity
{
    public string Date { get; set; }
    public int Duration { get; set; } // Duration in minutes

    protected Activity(string date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"Date: {Date}\nDuration: {Duration} minutes\nDistance: {GetDistance()} km\nSpeed: {GetSpeed()} km/h\nPace: {GetPace()} min/km";
    }
}

// Running class derived from Activity
class Running : Activity
{
    public double Distance { get; set; } // Distance in kilometers

    public Running(string date, int duration, double distance) 
        : base(date, duration)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (Duration / 60.0);
    }

    public override double GetPace()
    {
        return Duration / Distance;
    }

    public override string GetSummary()
    {
        return $"Running:\n{base.GetSummary()}";
    }
}

// Stationary Bicycle class derived from Activity
class StationaryBicycle : Activity
{
    public double Speed { get; set; } // Speed in km/h

    public StationaryBicycle(string date, int duration, double speed) 
        : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return Speed * (Duration / 60.0);
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }

    public override string GetSummary()
    {
        return $"Stationary Bicycle:\n{base.GetSummary()}";
    }
}

// Swimming class derived from Activity
class Swimming : Activity
{
    public int Laps { get; set; }
    private const double LapDistance = 0.05; // Distance per lap in kilometers

    public Swimming(string date, int duration, int laps) 
        : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * LapDistance;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Duration / 60.0);
    }

    public override double GetPace()
    {
        return Duration / GetDistance();
    }

    public override string GetSummary()
    {
        return $"Swimming:\n{base.GetSummary()}";
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("2023-06-28", 30, 5),       // Date, duration in minutes, distance in km
            new StationaryBicycle("2023-06-28", 45, 25), // Date, duration in minutes, speed in km/h
            new Swimming("2023-06-28", 20, 30)      // Date, duration in minutes, number of laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
