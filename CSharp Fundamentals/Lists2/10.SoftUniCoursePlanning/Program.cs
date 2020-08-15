using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string lessonTitle = command[1];
                if (command[0] == "Add")
                {
                    if (!list.Contains(lessonTitle))
                    {
                        list.Add(lessonTitle);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (!list.Contains(lessonTitle))
                    {
                        list.Insert(index, lessonTitle);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (list.Contains(lessonTitle))
                    {
                        list.Remove(lessonTitle);
                    }
                }
                else if (command[0] == "Swap")
                {
                    string secondLessonTitle = command[2];

                    if (list.Contains(lessonTitle) && list.Contains(secondLessonTitle))
                    {
                        int from = list.IndexOf(lessonTitle);
                        int to = list.IndexOf(secondLessonTitle);

                        string temp = list[from];
                        list[from] = list[to];
                        list[to] = temp;
                    }

                    if (list.Contains($"{lessonTitle}-Exercise"))
                    {
                        int tempIndex = list.IndexOf($"{lessonTitle}-Exercise");
                        list.Insert(list.IndexOf(lessonTitle + 1), ($"{lessonTitle}-Exercise"));
                        list.RemoveAt(tempIndex);
                    }

                    if (list.Contains($"{secondLessonTitle}-Exercise"))
                    {
                        int tempIndex = list.IndexOf($"{secondLessonTitle}-Exercise");
                        list.Insert(list.IndexOf(secondLessonTitle + 1), ($"{secondLessonTitle}-Exercise"));
                        list.RemoveAt(tempIndex);
                    }
                }
                else if (command[0] == "Exercise")
                {
                    if (list.Contains(lessonTitle))
                    {
                        list.Insert(list.IndexOf(lessonTitle) + 1, ($"{lessonTitle}-Exercise"));
                    }
                    else if ((!list.Contains(lessonTitle)) && (!list.Contains($"{lessonTitle}-Exercise")))
                    {
                        list.Add(lessonTitle);
                        list.Add($"{lessonTitle}-Exercise");
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }

        }

    }
}