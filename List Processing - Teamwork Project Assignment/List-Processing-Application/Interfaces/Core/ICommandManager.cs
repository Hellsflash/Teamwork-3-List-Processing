using System.Collections.Generic;

namespace List_Processing_Application.Interfaces.Core
{
    public interface ICommandManager
    {
        string Append(IList<string> args);

        string Prepend(IList<string>args);

        string Reverse(IList<string>args);

        string Insert(IList<string>args);

        string Delete(IList<string>args);

        string RollLeft(IList<string>args);

        string RollRight(IList<string>args);

        string Sort(IList<string>args);

        string Count(IList<string>args);

        string End(object argList);
    }
}
