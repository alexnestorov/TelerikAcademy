using MementoPattern.Contracts;

namespace MementoPattern.Models
{
    public class PersonMemento : IMemento
    {
        public PersonMemento(string firstName, string lastName, string cellPhone, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellPhone = cellPhone;
            this.Address = address;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string CellPhone { get; private set; }

        public string Address { get; private set; }
    }
}
