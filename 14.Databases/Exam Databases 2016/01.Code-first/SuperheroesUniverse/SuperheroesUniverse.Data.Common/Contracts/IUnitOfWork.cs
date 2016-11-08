using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Data.Common.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
