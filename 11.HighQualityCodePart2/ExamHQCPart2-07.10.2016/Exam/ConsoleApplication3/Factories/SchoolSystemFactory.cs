using ConsoleApplication3.Contracts;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Factories
{
    public class SchoolSystemFactory : ISchoolSystemFactory
    {
        public IStudent CreateStudent(string firstName, string lastName, string grade)
        {
            return new Student(firstName, lastName, grade);
        }

        public ITeacher CreateTeacher(string firstName, string lastName, int subjectId)
        {
            return new Teacher(firstName, lastName, subjectId);
        }
    }
}
