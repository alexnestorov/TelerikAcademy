using System;

using AdapterPattern.Contracts;

namespace AdapterPattern.Models
{
    public class Target : ITarget
    {
        public virtual string Request()
        {
            return string.Format("Called Target Request()");
        }
    }
}
