using System;

using ComputersExam.Contracts;

namespace ComputersExam.Common
{
    public class Motherboard : IMotherboard
    {
        private ICpu cpu;
        private IRam ram;
        private IVideoCard videoCard;

        public Motherboard(ICpu cpu, IRam ram, IVideoCard videoCard)
        {
            cpu.Motherboard = this;
            this.Cpu = cpu;

            ram.Motherboard = this;
            this.Ram = ram;

            videoCard.Motherboard = this;
            this.VideoCard = videoCard;
        }

        public ICpu Cpu
        {
            get
            {
                return this.cpu;
            }

            private set
            {
                if (value.Equals(null))
                {
                    throw new NullReferenceException("Not initialized motherboard part");
                }

                this.cpu = value;
            }
        }

        public IRam Ram
        {
            get
            {
                return this.ram;
            }

            private set
            {
                if (value.Equals(null))
                {
                    throw new NullReferenceException("Not initialized motherboard part");
                }

                this.ram = value;
            }
        }

        public IVideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }

            private set
            {
                if (value.Equals(null))
                {
                    throw new NullReferenceException("Not initialized motherboard part");
                }

                this.videoCard = value;
            }
        }

        public void DrawOnVideoCard(string storageData)
        {
            this.VideoCard.Draw(storageData);
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }
    }
}
