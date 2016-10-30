using System;
using System.Reflection;

using Ninject;
using MementoPattern.Contracts;
using MementoPattern.Models;

namespace MementoPattern
{
    /// <summary>
    /// Performs example for Memento Design Pattern.
    /// The example is based on this article and shows how this pattern works in real world environment.
    /// Folow the link below for more information
    /// https://sourcemaking.com/design_patterns/memento
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            // For creation I am using Ninject IoC Container.
            // More information about it you can see on the link below.
            // https://github.com/ninject/Ninject/blob/master/README.md
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var person = kernel.Get<Person>();
            person.Address = "bul. Al. Stamboliiski 118";
            person.CellPhone = "875122011185";
            person.FirstName = "John";
            person.LastName = "Cena";

            var caretaker = kernel.Get<ICaretaker>();
            caretaker.Add(person.CreateUnDo());

            Console.WriteLine(person.ShowInfo());
            Console.WriteLine(new string('-', 50));
            person.Address = "bul. Bulgaria 99";
            caretaker.Add(person.CreateUnDo());

            Console.WriteLine(person.ShowInfo());
            Console.WriteLine(new string('-', 50));

            person.CellPhone = "55444669";
            Console.WriteLine(person.ShowInfo());
            Console.WriteLine(new string('-', 50));

            person.UnDo(caretaker.GetMemento());
            person.ShowInfo();

            person.UnDo(caretaker.GetMemento());
            person.ShowInfo();
            Console.WriteLine(new string('-', 50));
        }
    }
}
