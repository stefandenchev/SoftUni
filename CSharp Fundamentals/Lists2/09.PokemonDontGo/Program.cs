using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (list.Count > 0)
            {
                bool removed = false;

                //int length = list.Count;
                int index = int.Parse(Console.ReadLine());
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == index)
                    {
                        if (i == list.Count - 1)
                        {
                            if (!removed)
                            {
                                sum += list[index];
                                list.RemoveAt(index);
                                if (list.Count == 0)
                                {
                                    break;
                                }
                                break;

                            }
                            if (list[i] <= list[index])
                            {
                                list[i] += list[index];
                            }
                            else if (list[i] > list[index])
                            {
                                list[i] -= list[index];
                            }
                        }
                        continue;
                    }

                    if (index < 0)
                    {
                        index = 0;           // list[index] = list.ElementAt(0);
                        list.Insert(0, list.Count - 1);
                        list.RemoveAt(1);
                        sum += list[index];
                        removed = true;
                    }

                    if (index > list.Count - 1) // - 1 ?
                    {
                        index = list.Count - 1;       // list[index] = list.ElementAt(list.Count - 1);
                        list.Insert(list.Count - 1, 0);
                        list.RemoveAt(list.Count - 2);
                        sum += list[index];
                        removed = true;
                    }

                    if (list[i] <= list[index])
                    {
                        list[i] += list[index];
                    }
                    else if (list[i] > list[index])
                    {
                        list[i] -= list[index];
                    }

                    if (i == list.Count - 1)
                    {
                        sum += list[index];
                        list.RemoveAt(index);
                    }
                }

            }
            Console.WriteLine(sum);
        }
    }
}
