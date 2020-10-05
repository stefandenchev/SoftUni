using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lillesInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rosesInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> lillies = new Stack<int>(lillesInput);
            Queue<int> roses = new Queue<int>(rosesInput);

            int count = 0;
            int remainder = 0;

            while (true)
            {
                if (lillies.Count == 0 || roses.Count == 0)
                {
                    break;
                }
                int currLil = lillies.Peek();
                int currRos = roses.Peek();
                int currTotal = currLil + currRos;
                bool more = false;
                if (currTotal > 15)

                {
                    more = true;
                }
                else if (currTotal == 15)
                {
                    lillies.Pop();
                    roses.Dequeue();
                    count++;
                }
                else
                {
                    remainder += currTotal;
                    lillies.Pop();
                    roses.Dequeue();
                }

                while (more)
                {
                    currTotal -= 2;
                    if (currTotal == 15)
                    {                      
                        count++;
                        more = false;
                        lillies.Pop();
                        roses.Dequeue();
                    }
                    else if(currTotal < 15)
                    {
                        remainder += currTotal;
                        more = false;
                        lillies.Pop();
                        roses.Dequeue();
                    }                   
                }
               
            }
            if (remainder > 0)
            {
                decimal additionalW = Math.Floor(remainder / 15.0m);
                count += (int)additionalW;
            }

            if (count >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {count} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - count} wreaths more!");
            }
        }
    }
}