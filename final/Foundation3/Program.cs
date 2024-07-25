

using System;
using System.Collections.Generic;

// Address class to store the address details
class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

// Base Event class
abstract class Event
{
    protected string Title { get; set; }
    protected string Description { get; set; }
    protected DateTime Date { get; set; }
    protected string Time { get; set; }
    protected Address Address { get; set; }

    protected Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}

// Lecture class derived from Event
class Lecture : Event
{
    private string Speaker { get; set; }
    private int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech", new DateTime(2023, 7, 10), "10:00 AM", address1, "Jane Doe", 100);

        List<Event> events = new List<Event> { lecture };

        foreach (var evt in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine("Full Details:");
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine("Short Description:");
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine();
        }
    }
}
