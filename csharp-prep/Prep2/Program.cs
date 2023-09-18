using System;

class Program
{
    static void Main(string[] args)
    {
        /*"int A = 90;
        int B = 80;
        int C = 70;
        int D = 60;*/
        //int F = 60;

        //Console.WriteLine($"{A} {B} {C} {D}");

        Console.Write("What is your grade percentage? ");
        string yourGrade = Console.ReadLine();
        int percent = int.Parse(yourGrade);

        if (percent >= 90)
        {
            Console.WriteLine("Your letter grade is A.");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("Your letter grade is B.");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("Your letter grade is C.");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("Your letter grade is D.");
        }
        else
        {
            Console.WriteLine("Your letter grade is F.");
        }


        if (percent > 70)
        {
            Console.WriteLine("You passed! (⌐■_■)");
        }
        else
        {
            Console.WriteLine("You failed... (╯°□°）╯︵ ┻━┻");
        }


        Console.WriteLine("");
        Console.WriteLine($"Your letter grade is {yourGrade}.");
    }
}