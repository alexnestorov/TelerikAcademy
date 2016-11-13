using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.Commands
{
    public abstract class Command : ICommand
    {
        private readonly IEngine engine;
        private readonly ISchoolSystemFactory schoolSystemFactory;

        protected Command()
        {

        }

        protected Command(IEngine engine, ISchoolSystemFactory schoolSystemFactory) : this()
        {
            if (engine == null)
            {
                throw new ArgumentNullException("Engine cannot be null");
            }

            if (schoolSystemFactory == null)
            {
                throw new ArgumentNullException("SchoolSystemFactory cannot be null");
            }

            this.engine = engine;
            this.schoolSystemFactory = schoolSystemFactory;
        }

        protected IEngine Engine { get { return this.engine; } }

        protected ISchoolSystemFactory SchoolSystemFactory { get { return this.schoolSystemFactory; } }

        public abstract string Execute(IList<string> parameters);
    }
}
