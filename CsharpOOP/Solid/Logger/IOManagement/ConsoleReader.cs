using LoggerEx.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}