using System;

using ConsoleApplication3.Abstracts;
using ConsoleApplication3.Contracts;
using ConsoleApplication3.Enums;

namespace ConsoleApplication3.Models
{
    public class Teacher : Person, ITeacher
    {
        private Subject subject;

        public Teacher(string firstName, string lastName, int subjectId)
            : base(firstName, lastName)
        {
            this.Subject = (Subject)Enum.Parse(typeof(Subject), subjectId.ToString());
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        public void AddMark(IStudent currentStudent, decimal studentMark)
        {
            var currentMark = new Mark(this.subject, studentMark);
            currentStudent.Marks.Add(currentMark);
        }
    }
}
