using log4net;
using log4net.Config;
using System;

namespace T4Template
{
    class Program
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Person person = new Person("Alexander", "Alexandrov", 25, "Sofia", "ITCompany", "DSK Klon Slavqnska beseda", "Master degree");
            Console.WriteLine(person.FirstName);

            XmlConfigurator.Configure();
            Log.Debug(person.FirstName);
        }
    }
}