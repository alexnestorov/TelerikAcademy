using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// Represents example of Singleton Design Pattern
    /// </summary>
    public sealed class CommandManager
    {
        private static readonly object SyncRoot = new object();
        private static CommandManager instance;

        private CommandManager()
        {
        }

        /// <summary>
        /// Gets property returns new instance of class.
        /// Using simple thread-safety
        /// For more information see the article below
        /// http://csharpindepth.com/Articles/General/Singleton.aspx
        /// </summary>
        public static CommandManager GetInstance
        {
            get
            {
                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new CommandManager();
                    }
                }

                return instance;
            }
        }

        public override string ToString()
        {
            var instanceSetResult = string.Empty;

            if (instance.Equals(null))
            {
                instanceSetResult = string.Format("{0} is not instanced yet.", this.GetType().Name);
            }
            else
            {
                instanceSetResult = string.Format("{0} is instanced correctly", this.GetType().Name);
            }

            return instanceSetResult;
        }
    }
}
