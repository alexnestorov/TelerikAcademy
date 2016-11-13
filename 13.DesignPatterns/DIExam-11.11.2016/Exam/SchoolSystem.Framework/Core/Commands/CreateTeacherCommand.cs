using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : Command, ICommand
    {
        private int currentTeacherId = 0;

        public CreateTeacherCommand(IEngine engine, ISchoolSystemFactory schoolSystemFactory)
            : base(engine, schoolSystemFactory)
        {
            this.currentTeacherId++;
        }

        public int CurrentTeacherId { get { return this.currentTeacherId; } }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.SchoolSystemFactory.CreateTeacher(firstName, lastName, subject);
            this.Engine.Teachers.Add(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {this.currentTeacherId++} was created.";
        }
    }
}
