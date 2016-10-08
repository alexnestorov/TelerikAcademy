using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[1]);
            var studentId = int.Parse(parameters[2]);

            // Please work
            var student = SchoolSystemEngine.Students[studentId];
            var teacher = SchoolSystemEngine.Teachers[teacherId];
            teacher.AddMark(student, decimal.Parse(parameters[3]));

            var result = string.Format($"Teacher {teacher.FirstName} {teacher.LastName} added mark {parameters[3]} to student {student.FirstName} {student.LastName} in {teacher.Subject}.");
            return result;
        }
    }
}
