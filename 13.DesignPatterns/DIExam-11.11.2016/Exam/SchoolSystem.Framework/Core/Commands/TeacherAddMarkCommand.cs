using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : Command, ICommand
    {
        private readonly IMarkFactory markFactory;

        public TeacherAddMarkCommand(IEngine engine, ISchoolSystemFactory schoolSystemFactory, IMarkFactory markFactory)
            : base(engine, schoolSystemFactory)
        {
            if (markFactory == null)
            {
                throw new ArgumentNullException("MarkFactory cannot be null");
            }

            this.markFactory = markFactory;
        }

        public override string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.Engine.Students[studentId];
            var teacher = this.Engine.Teachers[teacherId];

            teacher.AddMark(student, mark, this.markFactory);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
