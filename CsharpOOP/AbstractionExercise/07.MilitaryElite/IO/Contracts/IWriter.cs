using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
