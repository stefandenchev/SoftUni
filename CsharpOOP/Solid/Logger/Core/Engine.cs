using LoggerEx.Core.Contracts;
using LoggerEx.Enumerations;
using LoggerEx.Errors;
using LoggerEx.IOManagement.Contracts;
using LoggerEx.Models.Common;
using LoggerEx.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LoggerEx.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split('|').ToArray();

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact
                    (dateTimeStr, GlobalConstants.DateTimeFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);

            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}