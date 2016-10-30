using System;
using System.Reflection;

using Ninject;
using TemplateMethodPattern.Abstracts;
using TemplateMethodPattern.Models;

namespace TemplateMethodPattern
{
    /// <summary>
    /// Performs example for Template Method Design Pattern.
    /// The example is based on this article and shows how this pattern works in real world environment.
    /// Folow the link below for more information
    /// http://www.codeproject.com/Articles/482196/Understanding-and-Implementing-Template-Method-Des
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

            DataExporter exporter;

            // Export the data to Excel file
            exporter = kernel.Get<ExcelExporter>();
            exporter.ExportFormattedData();
            Console.WriteLine(new string('-', 50));

            // Export the data to PDF file
            exporter = kernel.Get<PdfExporter>();
            exporter.ExportFormattedData();
            Console.WriteLine(new string('-', 50));

            // Export the data to PDF file
            exporter = kernel.Get<XmlExporter>();
            exporter.ExportFormattedData();
            Console.WriteLine(new string('-', 50));

            // Export the data to PDF file
            exporter = kernel.Get<JsonExporter>();
            exporter.ExportFormattedData();
            Console.WriteLine(new string('-', 50));
        }
    }
}
