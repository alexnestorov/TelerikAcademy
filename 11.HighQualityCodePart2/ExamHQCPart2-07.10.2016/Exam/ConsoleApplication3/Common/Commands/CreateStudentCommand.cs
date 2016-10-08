using System.Collections.Generic;

using ConsoleApplication3.Enums;

namespace ConsoleApplication3.Common.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int studentId = 0;

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[1];
            string lastName = parameters[2];
            string studentGrade = parameters[3];
            SchoolSystemEngine.Students.Add(studentId, new Student(firstName, lastName, studentGrade));

            var result = string.Format($"A new student with name {firstName} {lastName}, grade {(Grade)int.Parse(studentGrade)} and ID {studentId++} was created.");
            return result;
        }
    }
}
