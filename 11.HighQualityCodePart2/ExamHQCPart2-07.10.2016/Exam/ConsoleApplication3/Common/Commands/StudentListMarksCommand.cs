using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentsMarksCount = int.Parse(parameters[1]);
            return SchoolSystemEngine.Students[int.Parse(parameters[1])].PrintStudentMarks();
        }
    }
}
