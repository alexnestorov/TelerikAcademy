using System;

using CompositePattern.Abstracts;
using CompositePattern.Contracts;

namespace CompositePattern.Models
{
    public class Worker : Employee, IEmployee
    {
        public Worker(string name, int numberOfCompletedTasks)
            : base (name, numberOfCompletedTasks)
        {

        }
    }
}
