using ConsoleApplication3.Common;
using ConsoleApplication3.Contracts;
using ConsoleApplication3.Enums;

namespace ConsoleApplication3
{
    public class Mark : IMark
    {
        private Subject subject;
        private decimal subjectValue;

        public Mark(Subject schoolSubject, decimal subjectValue)
        {
            this.Subject = schoolSubject;
            this.SubjectValue = subjectValue;
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        public decimal SubjectValue
        {
            get
            {
                return this.subjectValue;
            }

            private set
            {
                Validator.ValidateNull(value, "Value");
                Validator.ValidateDecimalRange(value, Constants.MinMarkValue, Constants.MaxMarkValue, "Value");
                this.subjectValue = value;
            }
        }
    }
}
