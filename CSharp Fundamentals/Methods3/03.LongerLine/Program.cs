using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                double x3 = double.Parse(Console.ReadLine());
                double y3 = double.Parse(Console.ReadLine());
                double x4 = double.Parse(Console.ReadLine());
                double y4 = double.Parse(Console.ReadLine());

            FindLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void FindLongerLine(double x1, double y1, double x2, double y2,
                                     double x3, double y3, double x4, double y4)
        {
            double horizontalDiff1 = Math.Max(x1, x2) - Math.Min(x1, x2);
            double verticalDiff1 = Math.Max(y1, y2) - Math.Min(y1, y2);
            double horizontalDiff2 = Math.Max(x3, x4) - Math.Min(x3, x4);
            double verticalDiff2 = Math.Max(y3, y4) - Math.Min(y3, y4);

            double result1 = Math.Sqrt(Math.Pow(horizontalDiff1, 2) + Math.Pow(verticalDiff1, 2));
            double result2 = Math.Sqrt(Math.Pow(horizontalDiff2, 2) + Math.Pow(verticalDiff2, 2));

            if (result1 >= result2)
            {
                double center1 = Math.Abs(x1) + Math.Abs(y1);
                double center2 = Math.Abs(x2) + Math.Abs(y2);

                if (center1 <= center2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                double center1 = Math.Abs(x3) + Math.Abs(y3);
                double center2 = Math.Abs(x4) + Math.Abs(y4);

                if (center1 <= center2)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}
