using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IDictionary<int, ITeacher> Teachers { get; }

        IDictionary<int, IStudent> Students { get; }
    }
}
