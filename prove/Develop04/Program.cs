

using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessActivities
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }

    class Menu
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Start();
                        break;
                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Start();
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Start();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }

    abstract class Activity
    {
        protected int Duration;

        public void Start()
        {
            ShowStartingMessage();
            PerformActivity();
            ShowEndingMessage();
        }

        protected void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine(GetName());
            Console.WriteLine(GetDescription());
            Console.Write("Enter the duration of the activity in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }

        protected void ShowEndingMessage()
        {
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {GetName()} for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b|");
                Thread.Sleep(250);
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        protected abstract string GetName();
        protected abstract string GetDescription();
        protected abstract void PerformActivity();
    }

    class BreathingActivity : Activity
    {
        protected override string GetName() => "Breathing Activity";

        protected override string GetDescription() => "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        protected override void PerformActivity()
        {
            for (int i = 0; i < Duration; i += 10)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(5);
                Console.WriteLine("Breathe out...");
                ShowCountdown(5);
            }
        }

        private void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }

    class ReflectionActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        protected override string GetName() => "Reflection Activity";

        protected override string GetDescription() => "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);

            for (int i = 0; i < Duration; i += 10)
            {
                string question = Questions[random.Next(Questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(10);
            }
        }
    }

    class ListingActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string GetName() => "Listing Activity";

        protected override string GetDescription() => "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You have a few seconds to think about your prompt...");
            ShowSpinner(5);
            Console.WriteLine("Start listing items now:");

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            List<string> items = new List<string>();
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine($"You listed {items.Count} items.");
        }
    }
}
