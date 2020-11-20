using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputTokens = args.Split();

            string commandType = inputTokens[0];
            string[] commandArguments = inputTokens.Skip(1).ToArray();

            string result = string.Empty;

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandType}Command");

            ICommand instance = (ICommand)Activator.CreateInstance(type);

            result = instance.Execute(commandArguments);
            // result = instance?.Execute(commandArguments) ?? "Invalid Command";

            return result;
        }
    }
}