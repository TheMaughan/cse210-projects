using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();

        Fraction nothing = new();

        Console.WriteLine(nothing.GetFractionString());
        Console.WriteLine(nothing.GetDecimalValue());
        Console.WriteLine();

        
        Fraction wholeNum = new(5);

        Console.WriteLine(wholeNum.GetFractionString());
        Console.WriteLine(wholeNum.GetDecimalValue());
        Console.WriteLine();

        
        
        Fraction fraction1 = new(3,4);

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine();

        
        Fraction fraction2 = new(1,3);

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine();

    }
}