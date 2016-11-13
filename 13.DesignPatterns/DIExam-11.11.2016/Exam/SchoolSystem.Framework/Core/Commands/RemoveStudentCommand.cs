using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : Command, ICommand
    {

        public RemoveStudentCommand(IEngine engine, ISchoolSystemFactory schoolSystemFactory)
            : base(engine, schoolSystemFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.Engine.Students.Remove(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
