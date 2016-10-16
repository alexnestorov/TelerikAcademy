using System;
using System.Reflection;

namespace CompanySampleImporter
{
    public class Startup
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
