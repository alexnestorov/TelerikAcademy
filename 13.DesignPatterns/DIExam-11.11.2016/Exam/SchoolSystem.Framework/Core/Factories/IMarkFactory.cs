using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.Factories
{
    public interface IMarkFactory
    {
        IMark CreateMark(Subject subject, float value);
    }
}
