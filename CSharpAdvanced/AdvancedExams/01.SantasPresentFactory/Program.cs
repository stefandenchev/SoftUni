using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] magicInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(materialsInput);
            Queue<int> magic = new Queue<int>(magicInput);

            int dolls = 0;
            int trains = 0;
            int bears = 0;
            int bicycles = 0;

            while (materials.Count > 0 && magic.Count > 0)
            {
                int currMat = materials.Peek();
                int currMag = magic.Peek();
                int currToy = currMat * currMag;

                if (currToy == 150)
                {
                    dolls++;
                    materials.Pop();
                    magic.Dequeue();
                }

                else if (currToy == 250)
                {
                    trains++;
                    materials.Pop();
                    magic.Dequeue();
                }

                else if (currToy == 300)
                {
                    bears++;
                    materials.Pop();
                    magic.Dequeue();
                }

                else if (currToy == 400)
                {
                    bicycles++;
                    materials.Pop();
                    magic.Dequeue();
                }

                else if (currToy > 0)
                {
                    magic.Dequeue();
                    int newMat = currMat + 15;
                    materials.Pop();
                    materials.Push(newMat);
                }

                else if (currToy < 0)
                {
                    currToy = currMat + currMag;
                    materials.Pop();
                    magic.Dequeue();
                    materials.Push(currToy);
                }

                else if (currMat == 0 || currMag == 0)
                {
                    if (currMat == 0)
                    {
                        materials.Pop();
                    }
                    if (currMag == 0)
                    {
                        magic.Dequeue();
                    }
                }
            }

            if ((dolls >= 1 && trains >= 1) || (bears >= 1 && bicycles >= 1))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {String.Join(", ", materials)}");              
            }

            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {String.Join(", ", magic)}");
            }

            if (bicycles > 0)
            {
                Console.WriteLine($"Bicycle: {bicycles}");
            }

            if (dolls > 0)
            {
                Console.WriteLine($"Doll: {dolls}");
            }

            if (bears > 0)
            {
                Console.WriteLine($"Teddy bear: {bears}");
            }

            if (trains > 0)
            {
                Console.WriteLine($"Wooden train: {trains}");
            }
        }
    }
}