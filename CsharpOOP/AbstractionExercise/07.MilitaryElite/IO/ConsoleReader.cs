using _07.MilitaryElite.IO.Contracts;
using System;

namespace _07.MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
