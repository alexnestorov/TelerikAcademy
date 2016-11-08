using System.Collections.Generic;

using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public interface IDealershipEngine : IEngine
    {
        IDealershipFactory Factory { get; }

        ICollection<IUser> Users { get; }

        IUser LoggedUser { get; set; }
    }
}
