using System;
class Program
{
    static void Main(string[] args)
    {
        // Create addressrs
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Oak St", "London", "Greater London", "UK");
        Address address3 = new Address("789 Pine St", "New York", "NY", "USA");

        // Create events
        Lecture lecture = new Lecture("Tech Talk", "An engaging talk on AI.", "2024-08-01", "10:00 AM", address1, "Dr. Smith", 100);
        Reception reception = new Reception("Networking Event", "Meet and greet with industry professionals.", "2024-09-15", "6:00 PM", address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "A fun day at the park with games and food.", "2024-07-22", "12:00 PM", address3, "Sunny");

        // Display event details
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}