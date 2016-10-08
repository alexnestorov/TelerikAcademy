using System.Collections.Generic;

namespace ConsoleApplication3
{
    /// <summary>
    /// Represent an method which can execute commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Method for executing collection of string commands.
        /// </summary>
        /// <param name="parameters">
        /// Represent collection of string parameters, which are used to execute commands.
        /// </param>
        /// <returns></returns>
        string Execute(IList<string> parameters);
    }
}
