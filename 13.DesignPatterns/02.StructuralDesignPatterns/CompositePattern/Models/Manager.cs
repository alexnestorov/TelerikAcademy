using System;
using System.Collections.Generic;

using CompositePattern.Abstracts;
using CompositePattern.Contracts;
using System.Text;

namespace CompositePattern.Models
{
    public class Manager : Employee, IEmployee
    {
        private ICollection<IEmployee> secondaries;

        public Manager(string name, int numberOfCompletedTasks, ICollection<IEmployee> secondaryWorkers)
            : base(name, numberOfCompletedTasks)
        {
            this.secondaries = secondaryWorkers;
        }

        public override string WorkResponsibilities()
        {
            var viewResponsibilities = new StringBuilder();
            viewResponsibilities.AppendLine(base.WorkResponsibilities());

            //show all the subordinate's lines of code
            foreach (IEmployee employee in secondaries)
            {
                viewResponsibilities.AppendLine(employee.WorkResponsibilities());
            }

            return viewResponsibilities.ToString().TrimEnd();
        }

        public void AddSubordinate(IEmployee employee)
        {
            secondaries.Add(employee);
        }
    }
}
