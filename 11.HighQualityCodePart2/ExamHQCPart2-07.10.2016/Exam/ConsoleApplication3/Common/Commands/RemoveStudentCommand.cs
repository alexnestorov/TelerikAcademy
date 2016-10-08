using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            SchoolSystemEngine.Students.Remove(int.Parse(parameters[1]));

            var result = string.Format($"Student with ID {int.Parse(parameters[1])} was sucessfully removed.");

            return result;
        }
    }
}
