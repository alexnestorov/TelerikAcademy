using SchoolSystem.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.Factories
{
    public interface ICommandFactory
    {
       ICommand GetCommand(TypeInfo commandTypeInfo);
    }
}
