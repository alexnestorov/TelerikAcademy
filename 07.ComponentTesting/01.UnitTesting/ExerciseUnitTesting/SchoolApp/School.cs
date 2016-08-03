namespace SchoolApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        private string schoolName;
        private ICollection<Course> schoolCourses;

        public School(string name)
        {
            this.Name = name;
            this.schoolCourses = new List<Course>();
        }

        public string Name
        {
            get { return this.schoolName; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("School must have a name");
                }
                this.schoolName = value;
            }
        }
        public ICollection<Course> Courses
        {
            get { return this.schoolCourses; }
            private set { this.schoolCourses = value; }
        }

        public void AddCourse(Course courseToAdd)
        {
            if (this.schoolCourses.Any(x => x.Equals(courseToAdd)))
            {
                throw new ArgumentException("Course is already add to this school");
            }
            this.schoolCourses.Add(courseToAdd);
        }
        public void RemoveCourse(Course courseToRemove)
        {
            if (!this.schoolCourses.Any(x => x.Equals(courseToRemove)))
            {
                throw new ArgumentException("Can not remove non existing course for this school");
            }
            this.schoolCourses.Remove(courseToRemove);

        }
    }
}

