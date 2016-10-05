using System;
using ComputersExam.Contracts;

namespace ComputersExam.Common
{
    public class MotherboardPart : IMotherboardPart
    {
        public IMotherboard Motherboard { get; set; }
    }
}
