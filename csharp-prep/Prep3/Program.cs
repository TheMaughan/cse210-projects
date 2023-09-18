using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        Console.WriteLine($"Number is {number}");
        /*for (int i = 2; i <= 20; i = i + 2)
        {
            Console.WriteLine(i);
        }*/

        Console.WriteLine("The magic number is bettween 1 & 10.");

        int guess = -1;


        while (guess != number)
        {
            Console.Write("What is the magic number? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Guess Higher (⌐_⌐ )");
            }
            else if (guess > number)
            {
                Console.WriteLine("Guess Lower ( ¬_¬)");
            }
            else
            {
                Console.WriteLine("You guessed it! (⌐■_■)");
            }
        }
    }
}