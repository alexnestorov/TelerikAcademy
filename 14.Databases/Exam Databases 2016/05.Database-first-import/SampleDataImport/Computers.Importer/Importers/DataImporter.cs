using Computers.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Importer.Importers
{
    public class DataImporter
    {
        private TextWriter textWriter;

        public static DataImporter Create(TextWriter textWriter)
        {
            return new DataImporter(textWriter);
        }

        private DataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                            && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .OfType<IImporter>()
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    textWriter.Write(i.Message);
                    var db = new ComputersDbEntities();
                    i.Get(db, this.textWriter);

                    textWriter.WriteLine();
                });
        }
    }
}
