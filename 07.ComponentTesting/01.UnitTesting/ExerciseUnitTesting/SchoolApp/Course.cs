namespace SchoolApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private string courseName;
        private ICollection<Student> setOfStudents;

        public Course(string name)
        {
            this.Name = name;
            this.setOfStudents = new SortedSet<Student>();
        }

        public string Name
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("You must enter course name.");
                }
                this.courseName = value;
            }
        }
        public ICollection<Student> SetOfStudents
        {
            get
            {
                return this.setOfStudents;
            }
            private set
            {
                this.setOfStudents = value;
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (this.setOfStudents.Count > 29)
            {
                throw new ArgumentOutOfRangeException("Can not add more students in this course");
            }
            this.setOfStudents.Add(studentToAdd);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (!this.setOfStudents.Contains(studentToRemove))
            {
                throw new ArgumentException("Non existing student");
            }
            this.setOfStudents.Remove(studentToRemove);
        }
    }
}
