using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var elements = input.Split(" : ");
                string courseName = elements[0];
                string studentName = elements[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }
            }

            foreach (var pair in courses.OrderByDescending(course => course.Value.Count))
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.Count);
                List<string> students = pair.Value;
                students.Sort();
                foreach (string student in students)
                {
                    Console.WriteLine("-- " + student);
                }
            }

        }
    }
}