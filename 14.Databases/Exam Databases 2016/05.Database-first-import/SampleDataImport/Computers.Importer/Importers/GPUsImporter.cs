using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Data;

namespace Computers.Importer.Importers
{
    public class GPUsImporter : IImporter
    {
        private const int NumberOfGPUs = 15;

        public Action<ComputersDbEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueVendor = new HashSet<string>();
                    var uniqueModel = new HashSet<string>();
                    var uniqueMemory = new HashSet<string>();

                    while (uniqueVendor.Count < NumberOfGPUs)
                    {
                        uniqueVendor.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueModel.Count < NumberOfGPUs)
                    {
                        uniqueModel.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueMemory.Count < NumberOfGPUs)
                    {
                        uniqueMemory.Add(RandomGenerator.GetRandomString(5, 10));
                    }

                    var uniqueVendorList = uniqueVendor.ToList();
                    var uniqueModelList = uniqueModel.ToList();
                    var currentIndex = 0;
                    var gpuType = "internal";
                    for (int i = 0; i < NumberOfGPUs; i++)
                    {
                        if (i == 5)
                        {
                            gpuType = "external";
                        }

                        this.AddGPUs(db, uniqueVendorList[i], uniqueModelList[i], gpuType, RandomGenerator.GetRandomString(5, 10));

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
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing GPUs";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        private void AddGPUs(ComputersDbEntities db, string name, string model, string type, string memory)
        {
            db.GPUs.Add(new GPUs
            {
                Vendor = name,
                Model = model,
                GPUType = type,
                Memory = memory
            });
        }
    }
}
