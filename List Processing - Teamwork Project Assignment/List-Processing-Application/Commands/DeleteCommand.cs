using System.Collections.Generic;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Commands
{
    public class DeleteCommand:Command
    {
        public DeleteCommand(IList<string> args, ICommandManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.Delete(Args);
        }
    }
}