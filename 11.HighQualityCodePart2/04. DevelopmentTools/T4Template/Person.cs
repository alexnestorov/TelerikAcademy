using System;
using System.Text;
using System.Collections.Generic;

namespace T4Template
{
    public class Person
    {
        public Person(string firstname, string lastname, int age, string town, string workPlace, string bankAccount, string degree)
        {
            this.FirstName = firstname;

            this.LastName = lastname;

            this.Age = age;

            this.Town = town;

            this.WorkPlace = workPlace;

            this.BankAccount = bankAccount;

            this.UniversityDegree = degree;

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public string WorkPlace { get; private set; }

        public string BankAccount { get; private set; }

        public string UniversityDegree { get; private set; }
    }
}