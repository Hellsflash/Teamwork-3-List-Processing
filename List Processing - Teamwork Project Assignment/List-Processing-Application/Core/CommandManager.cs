﻿using System;
using System.Collections.Generic;
using System.Linq;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Core
{
    using System.Runtime.InteropServices;

    public class CommandManager
    {
        private const string InvalidCommandParameters = "Error: invalid command parameters";

        public string Append(IList<string> args, string initial)
        {
            if (args.Count != 1)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            return initial + " " + args[0].ToString();
        }

        public string Prepend(IList<string> args, string initial)
        {
            if (args.Count != 1)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            var revesed = initial.Split(' ').Reverse().ToList();
            revesed.Add(args[0]);
            revesed.Reverse();
            return string.Join(" ", revesed);
        }

        public string Reverse(string initial)
        {
            var list = initial.Split(' ');
            var revsed = list.Reverse();
            return string.Join(" ", revsed);
        }

        public string Insert(IList<string> args, string initial)
        {
            var index = int.Parse(args[0]);
            if (args.Count < 2)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            var arg = args[1];

            var list = initial.Split(' ').ToList();

            if (index < 0 || index > list.Count - 1)
            {
                throw new ArgumentException($"Error: invalid index {index}");
            }

            list.Insert(index, arg);
            return string.Join(" ", list);
        }

        public string Delete(IList<string> args, string initial)
        {

            var list = initial.Split(' ').ToList();

            if (args.Count != 1 || !int.TryParse(args[0], out int index))
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            if (index < 0 || index > list.Count - 1)
            {
                throw new ArgumentException($"Error: invalid index {index}");
            }

            list.RemoveAt(index);

            return string.Join(" ", list);
        }

        public string Roll(IList<string> args, string initial)
        {
            var list = initial.Split(' ').ToList();
            var direction = args[0];

            if (direction == "left")
            {
                var listEnd = list.Count - 1;
                var shiftedElement = list[0];

                for (int i = 0; i < listEnd; i++)
                {
                    list[i] = list[i + 1];
                }

                list[listEnd] = shiftedElement;
            }
            else if (direction == "right")
            {
                var listEnd = list.Count - 1;
                var shiftedElement = list[listEnd];

                for (int i = listEnd; i > 0; i--)
                {
                    list[i] = list[i - 1];
                }

                list[0] = shiftedElement;
            }
            else
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            return string.Join(" ", list);
        }

        //public string RollLeft(string initial)
        //{
        //    var list = initial.Split(' ').ToList();

        //    var listEnd = list.Count - 1;
        //    var shiftedElement = list[0];

        //    for (int i = 0; i < listEnd; i++)
        //    {
        //        list[i] = list[i + 1];
        //    }

        //    list[listEnd] = shiftedElement;

        //    return string.Join(" ", list);
        //}

        //public string RollRight(string initial)
        //{
        //    var list = initial.Split(' ').ToList();

        //    var listEnd = list.Count - 1;
        //    var shiftedElement = list[listEnd];

        //    for (int i = listEnd; i > 0; i--)
        //    {
        //        list[i] = list[i - 1];
        //    }

        //    list[0] = shiftedElement;

        //    return string.Join(" ", list);
        //}

        public string Sort(string initial)
        {
            var orderedList = initial.Split(' ')
                .ToList()
                .OrderBy(s => s);

            return string.Join(" ", orderedList);
        }

        public int Count(IList<string> args, string initial)
        {
            var list = initial.Split(' ').ToList();
            var counter = 0;
            var wantedString = args[0];

            foreach (var element in list)
            {
                if (element == wantedString)
                {
                    counter++;
                }             
            }

            return counter;
        }

        public string End()
        {
            return "Finished";
        }
    }
}