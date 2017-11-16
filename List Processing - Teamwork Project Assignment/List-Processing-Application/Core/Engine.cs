namespace List_Processing_Application.Core
{
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
        }
    }
}
