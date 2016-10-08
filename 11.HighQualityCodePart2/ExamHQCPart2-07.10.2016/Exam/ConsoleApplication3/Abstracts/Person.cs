using ConsoleApplication3.Common;
using ConsoleApplication3.Contracts;

namespace ConsoleApplication3.Abstracts
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateNull(value, "FirstName");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, "FirstName");
                Validator.ValidateSymbols(value, Constants.PersonNamePattern, "FirstName");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateNull(value, "LastName");
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength, "LastName");
                Validator.ValidateSymbols(value, Constants.PersonNamePattern, "LastName");

                this.lastName = value;
            }
        }
    }
}
