namespace List_Processing_Application.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using List_Processing_Application.Interfaces.Core;

    public class CommandManager
    {
        private const string InvalidCommandParameters = "Error: invalid command parameters";

        public string Append(IList<string> input, string initial)
        {
            if (input.Count != 2)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            return initial + " " + input[1].ToString();
        }

        public string Prepend(IList<string> input, string initial)
        {
            if (input.Count != 2)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            var revesed = initial.Split(' ').Reverse().ToList();
            revesed.Add(input[1]);
            revesed.Reverse();
            return string.Join(" ", revesed);
        }

        public string Reverse(IList<string> input, string initial)
        {
            if (input.Count > 1)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }
            var list = initial.Split(' ');
            var revsed = list.Reverse();
            return string.Join(" ", revsed);
        }

        public string Insert(IList<string> input, string initial)
        {
            var list = initial.Split(' ').ToList();

            if (input.Count != 3 || !int.TryParse(input[1], out int index))
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            if (index < 0 || index > list.Count - 1)
            {
                throw new ArgumentException($"Error: invalid index {index}");
            }

            var argument = input[2];

            list.Insert(index, argument);
            return string.Join(" ", list);
        }

        public string Delete(IList<string> input, string initial)
        {

            var list = initial.Split(' ').ToList();

            if (input.Count != 2 || !int.TryParse(input[1], out int index))
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

        public string Roll(IList<string> input, string initial)
        {
            var list = initial.Split(' ').ToList();

            if (input.Count != 2 || (input[1] != "left" && input[1] != "right"))
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            if (input[1] == "left")
            {
                var listEnd = list.Count - 1;
                var shiftedElement = list[0];

                for (int i = 0; i < listEnd; i++)
                {
                    list[i] = list[i + 1];
                }

                list[listEnd] = shiftedElement;
            }
            else
            {
                var listEnd = list.Count - 1;
                var shiftedElement = list[listEnd];

                for (int i = listEnd; i > 0; i--)
                {
                    list[i] = list[i - 1];
                }

                list[0] = shiftedElement;
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

        public string Sort(IList<string> input, string initial)
        {
            if (input.Count > 1)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            var orderedList = initial.Split(' ')
                .ToList()
                .OrderBy(s => s);

            return string.Join(" ", orderedList);
        }

        public string Count(IList<string> input, string initial)
        {
            if (input.Count != 2)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            var list = initial.Split(' ').ToList();
            var counter = 0;
            var wantedString = input[1];

            foreach (var element in list)
            {
                if (element == wantedString)
                {
                    counter++;
                }
            }

            return counter.ToString();
        }

        public string End(IList<string> input)
        {
            if (input.Count != 1)
            {
                throw new ArgumentException(InvalidCommandParameters);
            }

            return "Finished";
        }
    }
}