using Computers.Importer.Importers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DataImporter.Create(Console.Out).Import();
        }
    }
}
