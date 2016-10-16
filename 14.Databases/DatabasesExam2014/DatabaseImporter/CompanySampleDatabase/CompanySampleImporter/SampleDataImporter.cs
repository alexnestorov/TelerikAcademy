using System;
using System.IO;
using System.Linq;
using System.Reflection;

using CompanySampleImporter.Contracts;

namespace CompanySampleImporter
{
   public class SampleDataImporter
    {
        private TextWriter textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            if (textWriter.Equals(null))
            {
                throw new ArgumentNullException("Textwriter can not be null");
            }

            this.textWriter = textWriter;
        }

        public void Import()
        {
            var types = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                                && !t.IsInterface && !t.IsAbstract)
                                .Select(t => (IImporter)Activator.CreateInstance(t))
                                .OrderBy(i => i.Order)
                                .ToList();

        }
    }
}
