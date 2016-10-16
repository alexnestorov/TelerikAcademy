using System;
using System.IO;
using System.Reflection;
using CompanySampleData;
using CompanySampleImporter.Contracts;

namespace CompanySampleImporter
{

    public class EmployeesImporter : IImporter
    {
        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Message
        {
            get
            {
                return "Importing employees";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
