using System;

using TemplateMethodPattern.Contracts;

namespace TemplateMethodPattern.Abstracts
{
    public abstract class DataExporter : IExporter
    {
        public void ReadData()
        {
            Console.WriteLine("Reading the data from SqlServer");
        }

        public void FormatData()
        {
            Console.WriteLine("Formatting the data as per requriements.");
        }

        public abstract string ExportData();

        public void ExportFormattedData()
        {
            this.ReadData();
            this.FormatData();
            this.ExportData();
        }
    }
}
