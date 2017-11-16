using System.Collections.Generic;
using System.Linq;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Core
{
    public class CommandManager
    {
        public string Append(IList<string> args, string initial)
        {
            return initial + " " + args[0].ToString();
        }

        public string Prepend(IList<string> args, string initial)
        {
            var revesed = initial.Split(' ').Reverse().ToList();
            revesed.Add(args[0]);
            revesed.Reverse();
            return string.Join(" ", revesed);
        }

        public string Reverse(string initial)
        {
            var reversed = initial.Reverse().ToList();
            return reversed.ToString();
        }

        public string Insert(IList<string> args, string initial)
        {
            var index = int.Parse(args[0]);
            var arg = args[1];

            var list = initial.Split(' ').ToList();
            list.Insert(index,arg);
            return string.Join(" ", list);
        }

        public string Delete(IList<string> args)
        {
            throw new System.NotImplementedException();
        }

        public string RollLeft(IList<string> args)
        {
            throw new System.NotImplementedException();
        }

        public string RollRight(IList<string> args)
        {
            throw new System.NotImplementedException();
        }

        public string Sort(IList<string> args)
        {
            throw new System.NotImplementedException();
        }

        public string Count(IList<string> args)
        {
            throw new System.NotImplementedException();
        }

        public string End(object argList)
        {
            throw new System.NotImplementedException();
        }
    }
}
