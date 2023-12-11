using System;

class Program
{
    static void Main(string[] args)
    {
        Event lecture = new Lecture("AI Conference", "How to survive the Terminator Event", DateTime.Now, new TimeSpan(14, 0, 0),
            new Address("123 Main St", "Paranoid Ville", "Texas", "12345"), "Joe Doenuts", 200);

        Event reception = new Reception("Miss Piggy & Kermit's Wedding", "Will this wedding ever happen?", DateTime.Now, new TimeSpan(18, 30, 0),
            new Address("456 Croak Place", "Muppetsville", "Backstage", "54321"), "greenlife@overtherainbow.tv");

        Event outdoorEvent = new OutdoorGathering("AT-ST Soccer Practice", "Team AT-ST vs team Gundam is this weekend, dont skip this practice!", DateTime.Now, new TimeSpan(12, 0, 0),
            new Address("88 ItsAGundam", "Irongiant Town", "Endor", "13579"), "Expect a 40% chance of scattered orbital strikes with a mild Ewok infestation from the wetern front.");

        // Call methods to generate marketing messages & output results
        Console.WriteLine("\nStandard Details");
        Console.WriteLine("------------------");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("==================\n");

        Console.WriteLine("Full Details:");
        Console.WriteLine("------------------");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine("==================\n");

        Console.WriteLine("Short Description:");
        Console.WriteLine("------------------");
        Console.WriteLine(lecture.GetShortDetails());
        Console.WriteLine("==================\n");
    }
}