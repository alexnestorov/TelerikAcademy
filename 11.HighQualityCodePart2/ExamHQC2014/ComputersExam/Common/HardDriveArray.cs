using System;
using System.Collections.Generic;
using System.Linq;

using ComputersExam.Contracts;

namespace ComputersExam.Common
{
    public class HardDriveArray : IHardDrive
    {
        private const string NoneExistingHardDriveInArrayMessage = "No hard drive in the RAID array!";

        private readonly IEnumerable<IHardDrive> hardDrives;

        public HardDriveArray()
        {
            this.hardDrives = new List<IHardDrive>();
        }

        public HardDriveArray(IEnumerable<IHardDrive> hardDrives)
        {
            this.hardDrives = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }
        }

        public IEnumerable<IHardDrive> HardDrives
        {
            get
            {
                return this.hardDrives;
            }
        }

        public void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new InvalidOperationException(NoneExistingHardDriveInArrayMessage);
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}
