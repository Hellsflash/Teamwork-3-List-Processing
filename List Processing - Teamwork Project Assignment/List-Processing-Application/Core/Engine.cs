﻿using System.Collections.Generic;
using System.Linq;

namespace List_Processing_Application.Core
{
    using System;
    using Interfaces.Core;
    public class Engine : IEngine
    {
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
                string inputLine = this.reader.ReadLine();
                List<string> arguments = this.ParseInput(inputLine);
                initialInput = this.ProcessInput(arguments, initialInput);
                this.writer.WriteLine(initialInput);
                isRunning = !this.ShouldEnd(inputLine);

            }
        }

        private List<string> ParseInput(string inputLine)
        {
            return inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        private string ProcessInput(List<string> arguments,string initialInput)
        {
            string command = arguments[0].First().ToString().ToUpper() + arguments[0].Substring(1);
            arguments.RemoveAt(0);
            if (command == "Roll")
            {
                command += arguments[0].First().ToString().ToUpper() + arguments[0].Substring(1);
                arguments.RemoveAt(0);
            }
            switch (command)
            {
                case "Append":
                    return manager.Append(arguments,initialInput);
                case "Prepend":
                    return manager.Prepend(arguments, initialInput);
                case "Reverse":
                    return manager.Reverse(initialInput);
                case "Insert":
                    return manager.Insert(arguments,initialInput);
                case "Delete":
                    return manager.Delete(arguments, initialInput);
                case "RollLeft":
                    return manager.RollLeft(initialInput);
                case "RollRight":
                    return manager.RollRight(initialInput);
                case "Sort":
                    return manager.Sort(arguments);
                case "Count":
                    return manager.Count(arguments);
                default:
                    return manager.End(arguments);
            }

        }
        private bool ShouldEnd(string inputLine)
        {
            return inputLine.Equals("end");
        }
    }
}
