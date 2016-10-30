using MementoPattern.Contracts;
using System.Collections.Generic;

namespace MementoPattern.Models
{
    public class PersonCaretaker : ICaretaker
    {
        private readonly Stack<IMemento> mementos = new Stack<IMemento>();

        public IMemento GetMemento()
        {
            return this.mementos.Pop();
        }

        public void Add(IMemento memento)
        {
            this.mementos.Push(memento);
        }
    }
}
