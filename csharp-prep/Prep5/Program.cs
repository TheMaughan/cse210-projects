using System;

class Program
{
    static void Main(string[] args)
    {
        Hello();

        string name = YourName();
        Console.WriteLine("");
        int number = FavNum();
        int squareNum  = SquareNum(number);
        Display(name, squareNum);
        Console.WriteLine("");
        
    }
    static void Hello()
    {
        Console.WriteLine("");
        Console.WriteLine("( ^_^)`/` Welcome to the Program!");
        Console.WriteLine("");
    }
    static string YourName()
    {
        Console.Write("( =_=)? What is your name? ");
        string userName = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine($"( ^o^)`/` Hello {userName}!");

        return userName;
    }
    static int FavNum()
    {
        Console.Write("*(¬_¬ )9 ~ Sooo... What's your favorite number? ");
        string userNum = Console.ReadLine();
        int num = int.Parse(userNum);

        return num;
    }
    
    static int SquareNum(int num)
    {
        int square = num * num;

        return square;
    }
    static void Display(string name, int square)
    {
        Console.WriteLine("");
        Console.WriteLine($"(⌐■_■)* {name}, the square of your favorite number is {square}!");
        Console.WriteLine("");
        Console.WriteLine("( T_T)`/` Good bye!");
    }
}