using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Data;

namespace Computers.Importer.Importers
{
    public class ComputersImporter : IImporter
    {
        private const int NumberOfComputers = 50;

        public Action<ComputersDbEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var uniqueVendor = new HashSet<string>();
                    var uniqueModel = new HashSet<string>();
                    var uniqueMemory = new HashSet<string>();

                   

                    var cpuIds = db.CPUs.Select(s => s.Id).ToList();
                    var gpuIds = db.GPUs.Select(g => g.Id).ToList();
                    var devicesIds = db.StorageDevices.Select(d => d.Id).ToList();

                    while (uniqueVendor.Count < NumberOfComputers)
                    {
                        uniqueVendor.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueModel.Count < NumberOfComputers)
                    {
                        uniqueModel.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueMemory.Count < NumberOfComputers)
                    {
                        uniqueMemory.Add(RandomGenerator.GetRandomString(5, 10));
                    }

                    var uniqueVendorList = uniqueVendor.ToList();
                    var uniqueModelList = uniqueModel.ToList();
                    var uniqueMemoryList = uniqueMemory.ToList();
                    var currentIndex = 0;
                    var cpType = "Notebook";
                    for (int i = 0; i < NumberOfComputers; i++)
                    {
                        if (i == 17)
                        {
                            cpType = "Desktop";
                        }
                        else if (i > 34)
                        {
                            cpType = "Ultrabook";
                        }

                        this.AddComputers(
                            db, 
                            cpType,
                            uniqueVendorList[i],
                            uniqueModelList[i],
                            cpuIds[RandomGenerator.GetRandomNumber(1,10)],
                            gpuIds[RandomGenerator.GetRandomNumber(1,10)],
                            devicesIds[RandomGenerator.GetRandomNumber(1,10)],
                            RandomGenerator.GetRandomNumber(2, 17).ToString() + " GB");

                        currentIndex++;

                        if (currentIndex % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (currentIndex % 100 == 0)
                        {
                            db.SaveChanges();
                            db = new ComputersDbEntities();
                        }
                    }

                    db.SaveChanges();
                    db.Configuration.AutoDetectChangesEnabled = true;
                    db.Configuration.ValidateOnSaveEnabled = true;
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing Computers";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }

        private void AddComputers(ComputersDbEntities db, string computerType, string name, string model, int cpuId, int gpuId, int storageId ,string memory)
        {
            db.Computers.Add(new Computers.Data.Computers
            {
                ComputerType = computerType,
                Vendor = name,
                Model = model,
                CPUId = cpuId,
                GPUId = gpuId,
                StorageDeviceId = storageId,
                Memory = memory
            });
        }
    }
}
