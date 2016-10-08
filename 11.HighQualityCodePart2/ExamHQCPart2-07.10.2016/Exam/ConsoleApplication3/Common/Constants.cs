using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Common
{
    public class Constants
    {
        // Object length
        public const int MinNameLength = 2;
        public const int MaxNameLength = 31;
        public const int MaxMarksCount = 20;
        public const int MinMarkValue = 2;
        public const int MaxMarkValue = 6;

        // Person pattern
        public const string PersonNamePattern = "^[A-Za-z]+$";
    }
}
