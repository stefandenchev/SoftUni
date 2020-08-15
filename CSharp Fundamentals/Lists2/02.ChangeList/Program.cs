using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elemenets = command.Split();

                if (elemenets[0] == "Delete")
                {
                    int elemenetToDelete = int.Parse(elemenets[1]);
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == elemenetToDelete)             // list.RemoveAll(x => x == elementToDelete) вместо for цикъл
                        {
                            list.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (elemenets[0] == "Insert")
                {
                    int elementToInsert = int.Parse(elemenets[1]);
                    int index = int.Parse(elemenets[2]);

                    list.Insert(index, elementToInsert);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
