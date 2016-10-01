using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputersExam.Common
{

    public class VideoCard
    {
        private bool isInRaid;
        private int hardDrivesInRaid;
        private int capacity;
        private Dictionary<int, string> data;
        private SortedDictionary<int, string> info;
        private List<VideoCard> hds;

        internal VideoCard()
        {
        }

        internal VideoCard(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.capacity = capacity;
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<VideoCard>();
        }

        internal VideoCard(int capacity, bool isInRaid, int hardDrivesInRaid, List<VideoCard> hardDrives)
        {
            this.capacity = capacity;
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.hds = hardDrives;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<VideoCard>();
        }

        public bool IsMonochrome { get; set; }

        public int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(a);
            Console.ResetColor();
        }

        internal void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        internal string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hds.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }
    }
}