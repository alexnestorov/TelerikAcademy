using HighQualityMethods.Methods.Enums;
using System;

namespace Methods
{
    class Student
    {

        public Student()
        {

        }

        public Student(string firstName, string lastName, DateTime birthday, TownType town, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthdayDate = birthday;
            this.Town = town;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthdayDate { get; set; }

        public TownType Town { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthdayDate.CompareTo(other.BirthdayDate) < 0;
        }
    }
}