using System;
using System.Collections.Generic;
using System.Text;

using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IDealershipEngine
    {
        private const string UserNotLogged = "You are not logged! Please login first!";
        private readonly ICommandProvider commandProvider;

        private IDealershipFactory factory;
        private ICollection<IUser> users;
        private IUser loggedUser;
        private IInputOutputProvider provider;

        public DealershipEngine(IDealershipFactory factory, IInputOutputProvider provider, ICommandProvider commandProvider)
        {
            if (factory == null)
            {
                throw new ArgumentNullException();
            }

            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            if (commandProvider == null)
            {
                throw new ArgumentNullException();
            }

            this.factory = factory;
            this.users = new List<IUser>();
            this.loggedUser = null;
            this.provider = provider;
            this.commandProvider = commandProvider;
        }

        public IDealershipFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IUser LoggedUser
        {
            get
            {
                return this.loggedUser;
            }

            set
            {
                this.loggedUser = value;
            }
        }

        public ICollection<IUser> Users
        {
            get
            {
                return this.users;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            this.users = new List<IUser>();
            this.loggedUser = null;
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }

        private IEnumerable<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            var currentLine = this.provider.Read();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.Factory.GetCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.provider.Read();
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(IEnumerable<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.provider.Write(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return this.commandProvider.ProvideSingleCommand(command, this);
        }
    }
}
