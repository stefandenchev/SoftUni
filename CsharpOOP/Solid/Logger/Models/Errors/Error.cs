using LoggerEx.Enumerations;
using LoggerEx.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            DateTime = dateTime;
            Message = message;
            Level = level;
        }
        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}