using System.Collections.Generic;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Commands
{
    public class CountCommand:Command
    {
        public CountCommand(IList<string> args, ICommandManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.Count(Args);
        }
    }
}