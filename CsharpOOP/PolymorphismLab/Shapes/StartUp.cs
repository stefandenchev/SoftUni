using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine($"{circle.CalculatePerimeter():f2}");
            Console.WriteLine($"{circle.Draw():f2}");

            Rectangle rectangle = new Rectangle(4, 6);
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
        }
    }
}