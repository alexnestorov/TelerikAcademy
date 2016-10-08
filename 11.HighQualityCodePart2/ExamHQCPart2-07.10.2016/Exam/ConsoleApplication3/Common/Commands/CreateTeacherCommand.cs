using System.Collections.Generic;

using ConsoleApplication3.Models;

namespace ConsoleApplication3.Common.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int teacherId = 0;

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[1];
            string lastName = parameters[2];
            int subject = int.Parse(parameters[3]);

            var teacher = new Teacher(firstName, lastName, subject);
            SchoolSystemEngine.Teachers.Add(teacherId, teacher);

            var result = string.Format($"A new teacher with name {teacher.FirstName} {teacher.LastName}, subject {teacher.Subject} and ID {teacherId++} was created.");
            return result;
        }
    }
}
