using TemplateMethodPattern.Abstracts;
using TemplateMethodPattern.Contracts;

namespace TemplateMethodPattern.Models
{
    /// <summary>
    /// Represents information exporting data in XML format.
    /// </summary>
    public class XmlExporter : DataExporter, IExporter
    {
        /// <summary>
        /// Defines current implementation of abstract method
        /// </summary>
        /// <returns>With type <see cref="string"/></returns>
        public override string ExportData()
        {
            return string.Format("Exporting the data to an Xml file.");
        }
    }
}
