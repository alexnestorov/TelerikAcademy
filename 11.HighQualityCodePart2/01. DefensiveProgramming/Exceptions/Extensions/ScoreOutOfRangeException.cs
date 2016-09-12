using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{
   public class ScoreOutOfRangeException : ArgumentOutOfRangeException
    {
        private int? max;
        private int? min;
        private int value;

        public ScoreOutOfRangeException(string msg)
            : base(msg)
        {
        }

        public ScoreOutOfRangeException(string msg, int value, int? min, int? max) : this(msg)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
    }
}
