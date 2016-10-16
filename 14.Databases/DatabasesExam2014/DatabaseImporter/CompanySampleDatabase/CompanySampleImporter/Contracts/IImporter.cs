using System;
using System.IO;

using CompanySampleData;

namespace CompanySampleImporter.Contracts
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; set; }

        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
