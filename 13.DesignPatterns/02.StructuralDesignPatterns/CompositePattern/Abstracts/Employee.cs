using CompositePattern.Contracts;

namespace CompositePattern.Abstracts
{
    public abstract class Employee : IEmployee
    {
        private string name;
        private int numberOfCompletedTasks;

        public Employee(string name, int numberOfCompletedTasks)
        {
            this.name = name;
            this.numberOfCompletedTasks = numberOfCompletedTasks;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int NumberOfCompletedTasks
        {
            get { return this.numberOfCompletedTasks; }
        }

        public virtual string WorkResponsibilities()
        {
            var viewResponsibilities = string.Format(this.Name + " has finished " + this.NumberOfCompletedTasks + " tasks for the month.");

            return viewResponsibilities;
        }
    }
}
