﻿using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Program.cs"))
            {
                string line = reader.ReadLine();
                int index = 0;
                while (line != null)
                {
                    if (index % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    index++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}