using System;
using System.Globalization;
using System.Net.Sockets;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numList = new List<int>();
        int number = -1;
        
        
        Console.WriteLine("");
        Console.WriteLine("Enter a list of numbers, type \"0\" when you're finished.");
        Console.WriteLine("");

        while (number != 0)
        {         
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());    

            //Console.WriteLine($"The number list is {number}");
            if (number != 0)
            {
                numList.Add(number);
            }
            // To remove an item from the end of a list:
            //numList.RemoveAt(numList.Count - 1);
        }
        Console.WriteLine("");

        // Get the Sum:
        int sum = 0;
        foreach (int newNum in numList)
        {
            sum += newNum;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        // Get the average:
        float average = ((float)sum) / numList.Count;
        Console.WriteLine($"The average is: {average}");
        

        //Get the min positive & max numbers:
        int min = int.MaxValue;
        foreach (var newNum in numList)
        {
            if (newNum > 0 && newNum < min)
            {
                min = newNum;
            }
        }

        if (numList.Count > 0)
        {
            int max = numList.Max();
            

            if (min != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {min}");
            }
            else
            {
                Console.WriteLine("There are no positive numbers in the list.");
            }

            Console.WriteLine($"The largest number is: {max}");
            
        }


        //Sort the list:
        Console.WriteLine("");
        numList.Sort();
        
        Console.WriteLine("The sorted list in order is:");
        foreach (var newNum in numList)
        {
            Console.Write(newNum + " ");
        }
        Console.WriteLine("");
        Console.WriteLine("");
    }
}