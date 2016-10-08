using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class RemoveTeacherCommand
    {
        public string Execute(IList<string> parameters)
        {
            var idToRemove = int.Parse(parameters[1]);
            SchoolSystemEngine.Teachers.Remove(idToRemove);

            var result = string.Format($"Student with ID {int.Parse(parameters[1])} was sucessfully removed.");

            return result;
        }
    }
}
