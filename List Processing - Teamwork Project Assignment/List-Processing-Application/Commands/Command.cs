using System.Collections.Generic;
using List_Processing_Application.Interfaces.Commands;
using List_Processing_Application.Interfaces.Core;

namespace List_Processing_Application.Commands
{
    public abstract class Command:ICommand
    {
        protected Command(IList<string> args, ICommandManager manager)
        {
           this.Args = args;
           this.Manager = manager;
        }
        public IList<string>Args { get; private set; }

        public ICommandManager Manager { get; private set; }

        public abstract string Execute();

    }
}