namespace List_Processing_Application.Core
{
    using System;
    using Interfaces.Core;
    using System.Collections.Generic;
    using System.Linq;

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
            string command = arguments[0];

            arguments.RemoveAt(0);

            if (arguments.Count == 0)
            {
                switch (command)
                {
                    case "reverse":
                        return manager.Reverse(initialInput);
                    case "sort":
                        return manager.Sort(initialInput);
                    case "end":
                        return manager.End();
                    default:
                        throw new ArgumentException(InvalidCommand);
                }
            }
            else if (arguments.Count == 1)
            {
                switch (command)
                {
                    case "append":
                        return manager.Append(arguments, initialInput);
                    case "prepend":
                        return manager.Prepend(arguments, initialInput);
                    case "roll":
                        return manager.Roll(arguments, initialInput);
                    case "delete":
                        return manager.Delete(arguments, initialInput);
                    case "count":
                        return manager.Count(arguments, initialInput);
                    default:
                        throw new ArgumentException(InvalidCommand);
                }
            }
            else
            {
                if (command != "insert")
                {
                    throw new ArgumentException(InvalidCommand);
                }
                else
                {
                    return manager.Insert(arguments, initialInput);
                }
            }
        }

        private bool ShouldEnd(string inputLine)
        {
            return inputLine.Equals("end");
        }
    }
}