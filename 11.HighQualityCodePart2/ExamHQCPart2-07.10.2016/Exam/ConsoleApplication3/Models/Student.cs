using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApplication3.Abstracts;
using ConsoleApplication3.Contracts;
using ConsoleApplication3.Enums;

namespace ConsoleApplication3
{
    public class Student : Person, IStudent
    {
        private readonly int studentId;
        private Grade grade;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, string grade)
            : base(firstName, lastName)
        {
            this.studentId++;
            this.Grade = (Grade)Enum.Parse(typeof(Grade), grade);
            this.marks = new List<IMark>();
        }

        public int Id
        {
            get
            {
                return this.studentId;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.grade = value;
            }
        }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                this.marks = value;
            }
        }

        public string PrintStudentMarks()
        {
            var studentMarks = this.marks.Select(m => $"{m.Subject} => {m.SubjectValue}")
                                    .ToList();
            var result = string.Empty;
            if (studentMarks.Count.Equals(0))
            {
                result = "This student has no marks";
            }
            else
            {
                result = string.Join(Environment.NewLine, studentMarks);
            }

            return result;
        }
    }
}
