using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle = new Cycling("04 Nov 2022", 45, 20.0);
        Swimming swim = new Swimming("05 Nov 2022", 25, 15);

        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);

        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}