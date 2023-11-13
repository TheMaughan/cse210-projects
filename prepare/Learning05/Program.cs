using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();


         Square s = new(2, "Black");
         shapes.Add(s);

         Circle c = new(2, "Yellow");
         shapes.Add(c);

         Rectangle r = new(2, 3, "Red");
         shapes.Add(r);

         foreach (Shape i in shapes)
         {
            string color = i.Color();

            double area = i.GetArea();

            string id = i.Identify();

            Console.WriteLine($"\nThe shape is a {id} and has a color of {color} with an area of {area}.\n");
         }


    }
}