using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : Command, ICommand
    {
        private int currentStudentId;

        public CreateStudentCommand(IEngine engine, ISchoolSystemFactory schoolSystemFactory)
            : base(engine, schoolSystemFactory)
        {
            this.currentStudentId++;
        }

        public int CurrentStudentId { get { return this.currentStudentId; } }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.SchoolSystemFactory.CreateStudent(firstName, lastName, grade);
            this.Engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
}
