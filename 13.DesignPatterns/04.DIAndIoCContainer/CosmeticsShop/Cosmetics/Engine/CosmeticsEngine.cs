using System;
using System.Collections.Generic;
using System.Text;

using Cosmetics.Contracts;

namespace Cosmetics.Engine
{
    public sealed class CosmeticsEngine : ICosmeticsEngine
    {
        private readonly ICosmeticsFactory factory;
        private readonly ICommandProvider commandProvider;
        private readonly IShoppingCart shoppingCart;

        private IInputOutputProvider provider;
        private readonly IDictionary<string, ICategory> categories;
        private readonly IDictionary<string, IProduct> products;

        public CosmeticsEngine(ICosmeticsFactory factory, 
            IShoppingCart shoppingCart, 
            IInputOutputProvider provider,
            ICommandProvider commandProvider)
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
            this.provider = provider;
            this.commandProvider = commandProvider;
            this.shoppingCart = shoppingCart;
            this.categories = new Dictionary<string, ICategory>();
            this.products = new Dictionary<string, IProduct>();
        }

        public ICosmeticsFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }
        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return this.products;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.provider.Read();

            while (!string.IsNullOrEmpty(currentLine))
            {
                ICommand currentCommand = this.factory.GetCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.provider.Read();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
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

        private string ProcessSingleCommand(ICommand command)
        {
            return this.commandProvider.ProvideSingleCommand(command);
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            this.provider.Write((output.ToString()));
        }
    }
}
