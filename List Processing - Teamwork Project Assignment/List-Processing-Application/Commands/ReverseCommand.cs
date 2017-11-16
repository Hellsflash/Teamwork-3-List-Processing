using System.Collections.Generic;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Commands
{
    public class ReverseCommand:Command
    {
        public ReverseCommand(IList<string> args, ICommandManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.Reverse(Args);
        }
    }
}