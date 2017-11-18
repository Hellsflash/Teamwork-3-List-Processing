using System.Collections.Generic;
using System.Linq;

namespace List_Processing_Application.Core
{
    using System;
    using System.Runtime.InteropServices;
    using Interfaces.Core;
    public class Engine : IEngine
    {
        private const string InvalidCommand = "Error: invalid command";

        private CommandManager manager;
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.manager = new CommandManager();
        }
        public void Run()
        {
            bool isRunning = true;

            string initialInput = this.reader.ReadLine();
            this.writer.WriteLine(initialInput);

            while (isRunning)
            {
                try
                {
                    string inputLine = this.reader.ReadLine();
                    List<string> arguments = this.ParseInput(inputLine);
                    initialInput = this.ProcessInput(arguments, initialInput);
                    this.writer.WriteLine(initialInput);
                    isRunning = !this.ShouldEnd(inputLine);
                }
                catch (ArgumentException ae)
                {
                  Console.WriteLine(ae.Message);                  
                }
                
            }
        }

        private List<string> ParseInput(string inputLine)
        {
            return inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        private string ProcessInput(List<string> arguments, string initialInput)
        {
            var availableCommands= new List<string>()
            {
                "append",
                "prepend",
                "reverse",
                "insert",
                "delete",
                "rollLeft",
                "rollRight",
                "sort",
                "count",
                "end"
            };
            string command = arguments[0];
            arguments.RemoveAt(0);
            if (command == "roll")
            {
                command += arguments[0].First().ToString().ToUpper() + arguments[0].Substring(1);
                arguments.RemoveAt(0);
            }

            if (!availableCommands.Contains(command))
            {
                throw new ArgumentException(InvalidCommand);
            }
            else
            {
                switch (command)
                {
                    case "append":
                        return manager.Append(arguments, initialInput);
                    case "prepend":
                        return manager.Prepend(arguments, initialInput);
                    case "reverse":
                        return manager.Reverse(initialInput);
                    case "insert":
                        return manager.Insert(arguments, initialInput);
                    case "delete":
                        return manager.Delete(arguments, initialInput);
                    case "rollLeft":
                        return manager.RollLeft(initialInput);
                    case "rollRight":
                        return manager.RollRight(initialInput);
                    case "sort":
                        return manager.Sort(initialInput);
                    case "count":
                        return manager.Count(arguments);
                    default:
                        return manager.End();
                }
            }   
        }
        private bool ShouldEnd(string inputLine)
        {
            return inputLine.Equals("end");
        }
    }
}
