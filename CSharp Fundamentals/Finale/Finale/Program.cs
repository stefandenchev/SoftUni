using System;

namespace Finale
{
    class Program
    {
        static void Main(string[] args)
        {
            string travelPlan = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                var elements = input.Split(":");

                if (input.Contains("Add Stop"))
                {
                    var index = int.Parse(elements[1]);
                    var newStop = elements[2];

                    if (index >= 0 && index <= travelPlan.Length - 1)
                    {
                        travelPlan = travelPlan.Insert(index, newStop);
                    }
                    Console.WriteLine(travelPlan);
                }

                if (input.Contains("Remove Stop"))
                {
                    var startIndex = int.Parse(elements[1]);
                    var endIndex = int.Parse(elements[2]);

                    if ((startIndex >= 0 && startIndex <= travelPlan.Length - 1) && (endIndex >= 0 && endIndex <= travelPlan.Length - 1))
                    {
                        travelPlan = travelPlan.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(travelPlan);
                }

                if (input.Contains("Switch"))
                {
                    var oldString = elements[1];
                    var newString = elements[2];

                    if (travelPlan.Contains(oldString))
                    {
                        travelPlan = travelPlan.Replace(oldString, newString);
                    }
                    Console.WriteLine(travelPlan);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelPlan}");

        }
    }
}