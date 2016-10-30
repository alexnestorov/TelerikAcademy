using System.Text;

using MementoPattern.Contracts;

namespace MementoPattern.Models
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CellPhone { get; set; }

        public string Address { get; set; }

        public IMemento CreateUnDo()
        {
            return new PersonMemento(this.FirstName, this.LastName, this.CellPhone, this.Address);
        }

        public void UnDo(IMemento memento)
        {
            this.FirstName = memento.FirstName;
            this.LastName = memento.LastName;
            this.CellPhone = memento.CellPhone;
            this.Address = memento.Address;
        }

        public string ShowInfo()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("FIRST NAME: {0}", this.FirstName));
            result.AppendLine(string.Format("LAST NAME: {0}", this.LastName));
            result.AppendLine(string.Format("ADDRESS: {0}", this.Address));
            result.AppendLine(string.Format("CELLPHONE: {0}", this.CellPhone));

            return result.ToString().TrimEnd();
        }
    }
}
