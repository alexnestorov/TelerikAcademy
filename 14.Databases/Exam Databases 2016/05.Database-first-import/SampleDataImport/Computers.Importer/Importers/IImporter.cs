using System;

using System.IO;

using Computers.Data;

namespace Computers.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<ComputersDbEntities, TextWriter> Get { get; }
    }
}
