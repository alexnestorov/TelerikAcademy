using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : Command, ICommand
    {
        public StudentListMarksCommand(IEngine engine, ISchoolSystemFactory schoolSystemFactory)
            : base(engine, schoolSystemFactory)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.Engine.Students[studentId];
            return student.ListMarks();
        }
    }
}
