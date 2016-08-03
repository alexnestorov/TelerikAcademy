using Cosmetics.Contracts;
using System.Collections.Generic;

namespace Cosmetics.Engine
{
    internal interface ICommandParser
    {
        IList<ICommand> ReadCommands();
    }
}