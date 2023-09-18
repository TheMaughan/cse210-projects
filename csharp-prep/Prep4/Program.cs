using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numList = new List<int>();
        int number = -1;

        
        
        Console.WriteLine("");
        Console.WriteLine("Enter a list of numbers, type \"0\" when you're finished.");
        
        while (number != 0)
        {         
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());    

            //Console.WriteLine($"The number list is {number}");
            if (number != 0)
            {
                numList.Add(number);
            }
        }


        Console.WriteLine("");
    }
}