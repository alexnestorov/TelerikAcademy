using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using ConsoleApplication3.Contracts;
using ConsoleApplication3.Models;

[assembly: InternalsVisibleTo("SchoolSystem.Tests")]
namespace ConsoleApplication3
{
    internal class SchoolSystemEngine : IEngine
    {
        private const char SplitterDelimiter = ' ';

        private IReader reader;
        private ISchoolSystemFactory factory;

        public SchoolSystemEngine(ISchoolSystemFactory schoolSystemFactory, IReader commandReader)
        {
            this.factory = schoolSystemFactory;
            this.reader = commandReader;
        }

        internal static Dictionary<int, ITeacher> Teachers { get; set; } = new Dictionary<int, ITeacher>();

        internal static Dictionary<int, IStudent> Students { get; set; } = new Dictionary<int, IStudent>();

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.Provider();
                    var commandParameters = command.Split(SplitterDelimiter);
                    var commandName = commandParameters[0];

                    if (commandName == "End")
                    {
                        break;
                    }

                    var assembli = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (typeInfo == null)
                    {
                        throw new ArgumentNullException("The passed command is not found!");
                    }

                    var commandInstance = Activator.CreateInstance(typeInfo) as ICommand;

                    this.PrintResult(commandInstance.Execute(commandParameters));
                }
                catch (Exception ex)
                {
                    this.PrintResult(ex.Message);
                }
            }
        }

        private void PrintResult(string message)
        {
            var messageParameters = message.Split();
            var newMessage = string.Join(" ", messageParameters);

            Console.WriteLine(message);
        }
    }
}
