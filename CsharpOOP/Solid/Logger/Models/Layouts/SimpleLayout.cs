using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
