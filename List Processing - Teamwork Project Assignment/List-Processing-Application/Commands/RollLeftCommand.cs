using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Commands
{
    public class RollLeftCommand:Command
    {
        public RollLeftCommand(IList<string> args, ICommandManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.RollLeft(Args);
        }
    }
}
