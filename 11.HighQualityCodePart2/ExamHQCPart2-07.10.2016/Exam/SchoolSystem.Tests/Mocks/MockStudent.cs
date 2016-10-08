using ConsoleApplication3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Tests
{
    public class MockStudent : Student
    {
        public MockStudent(string firstName, string lastName, string grade)
            :base(firstName, lastName, grade)
        {

        }
    }
}
