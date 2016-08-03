using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolUnitTest")]
namespace SchoolApp
{
    using System;

    public class Student : IComparable<Student>
    {
        private string name;
        private int studentID;

        public Student(string name, int id)
        {
            this.Name = name;
            this.StudentID = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("You must enter student name");
                }
                this.name = value;
            }
        }
        public int StudentID
        {
            get
            {
                return this.studentID;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Invalid student ID.");
                }
                this.studentID = value;
            }
        }

        public int CompareTo(Student comparingStudent)
        {
            if (this.Name.CompareTo(comparingStudent.Name) < 0)
            {
                return -1;
            }
            else if (this.Name.CompareTo(comparingStudent.Name) > 0)
            {
                return 1;
            }
            return 0;
        }
        internal void GetStudentsCount()
        {

        }
    }
}
