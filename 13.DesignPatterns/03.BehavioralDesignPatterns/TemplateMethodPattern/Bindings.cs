using Ninject.Modules;
using TemplateMethodPattern.Abstracts;
using TemplateMethodPattern.Contracts;
using TemplateMethodPattern.Models;

namespace MediatorPattern
{
    /// <summary>
    /// Setup information for bindings in current project.
    /// </summary>
    public class Bindings : NinjectModule
    {
        /// <summary>
        /// Returns information of loading bindings in project.
        /// </summary>
        public override void Load()
        {
            Bind<DataExporter>().ToSelf();
            Bind<IExporter>().To<ExcelExporter>();
            Bind<IExporter>().To<PdfExporter>();
            Bind<IExporter>().To<XmlExporter>();
            Bind<IExporter>().To<JsonExporter>();
        }
    }
}
