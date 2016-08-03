using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolApp;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace SchoolUnitTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void CheckSchoolNameAfterCreatingNewSchool()
        {
            var school = new School("National High School in Finance and Business");

            Assert.AreEqual("National High School in Finance and Business", school.Name, "School names are not the same");
        }

        [TestMethod]
        public void CheckNumberOfCourses()
        {
            var school = new School("National High School in Finance and Business");

            var courses = new string[] { "Algebra", "Geometry", "Mathematics", "Physics", "Biology" };
            for (int i = 0; i < 5; i++)
            {
                school.AddCourse(new Course(courses[i]));
            }

            Assert.AreEqual(5, school.Courses.Count, string.Format("Number of courses are {0}", school.Courses.Count));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingMoreThan30StudentsShouldThrowAnException()
        {
            var course = new Course("Algebra");
            for (int i = 0; i < 31; i++)
            {
                course.AddStudent(new Student("Ivan" + i, 20000 + i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithEmptyNameShouldThrowAnException()
        {
            var student = new Student("", 19999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithWhiteSpacesAsNameShouldThrowAnException()
        {
            var student = new Student("        ", 19999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCourseWithEmptyNameShouldThrowAnException()
        {
            var course = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCourseWithWhiteSpacesAsNameShouldThrowAnException()
        {
            var course = new Course("        ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingStudentWithIdLessThan10000IdShouldThrowAnException()
        {
            var student = new Student("Vasil", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingStudentWithIdGreaterThan99999IdShouldThrowAnException()
        {
            var student = new Student("Nikolay", 100000);
        }

        [TestMethod]
        public void CheckForAlphabeticallySortedStudents()
        {
            var expectedSortedStudents = new SortedSet<Student>()
            {
                new Student("Alexander Ognqnov",10000),
                new Student("Ernestina Slabakova", 10001),
                new Student("Petar Angelov", 10002),
                new Student("Petar Dimitrov",10003),
                new Student("Vasil Kunchev",10004)
            };
            var course = new Course("Algebra");
            var randomStudentsNames = new string[] { "Vasil Kunchev", "Petar Dimitrov", "Petar Angelov", "Alexander Ognqnov", "Ernestina Slabakova" };
            for (int i = 0; i < randomStudentsNames.Length; i++)
            {
                course.AddStudent(new Student(randomStudentsNames[i], 10002 + i));

            }
            CollectionAssert.Equals(expectedSortedStudents, (SortedSet<Student>)course.SetOfStudents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNonExistingStudentShouldThrowAnException()
        {
            var course = new Course("Macroeconomics");
            var studentToRemove = new Student("Georgi Avramov", 20000);
            course.AddStudent(new Student("Ivan Georgiev", 10000));
            course.RemoveStudent(studentToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingAlreadyExistingCourseShouldThrowAnException()
        {
            var school = new School("1 SOU Pencho Slaveikov");
            school.AddCourse(new Course("Algebra"));
            school.AddCourse(new Course("Geometry"));
            school.AddCourse(new Course("Geography"));

            var courseToRemove = new Course("Biology");
            school.RemoveCourse(courseToRemove);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingAlreadyExistingCourseShouldThrowAnException()
        {
            var school = new School("1 SOU Pencho Slaveikov");
            var course1 = new Course("Algebra");
            var course2 = new Course("Geometry");
            var course3 = new Course("Geography");

            school.AddCourse(course1);
            school.AddCourse(course2);
            school.AddCourse(course3);

            school.AddCourse(course1);
        }

        [TestMethod]
        public void AddingCourseShouldIncreaseCourseCount()
        {
            var school = new School("1 SOU Pencho Slaveikov");
            school.AddCourse(new Course("Algebra"));
            school.AddCourse(new Course("Geometry"));
            school.AddCourse(new Course("Geography"));

            var courseToAdd = new Course("Biology");
            school.AddCourse(courseToAdd);

            Assert.AreEqual(4, school.Courses.Count, "The adding of the course is successful");
        }

        [TestMethod]
        public void RemovingCourseShouldDecreaseCourseCount()
        {
            var school = new School("1 SOU Pencho Slaveikov");

            var course1 = new Course("Algebra");
            var course2 = new Course("Geometry");
            var course3 = new Course("Geography");


            school.AddCourse(course1);
            school.AddCourse(course2);
            school.AddCourse(course3);

            var courseToRemove = school.Courses.FirstOrDefault(x => x.Name == "Algebra");

            school.RemoveCourse(courseToRemove);

            Assert.AreSame(course1, courseToRemove, "The removing of the course is successful");
        }
    }
}
