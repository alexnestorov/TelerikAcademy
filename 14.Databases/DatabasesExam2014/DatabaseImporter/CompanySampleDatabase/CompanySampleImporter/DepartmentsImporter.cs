using System;
using System.IO;

using CompanySampleData;
using CompanySampleImporter.Contracts;

namespace CompanySampleImporter
{

    public class DepartmentsImporter : IImporter
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
                return "Importing departments";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
