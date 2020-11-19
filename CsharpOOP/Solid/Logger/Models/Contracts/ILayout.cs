using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx
{
    public interface ILayout
    {
        string Format { get; }
    }
}