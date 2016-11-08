using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Data;

namespace Computers.Importer.Importers
{
    public class StorageDevicesImporter : IImporter
    {
        private const int NumberOfStorageDevices = 30;

        public Action<ComputersDbEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueVendor = new HashSet<string>();
                    var uniqueModel = new HashSet<string>();
                    var uniqueMemory = new HashSet<string>();

                    while (uniqueVendor.Count < NumberOfStorageDevices)
                    {
                        uniqueVendor.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueModel.Count < NumberOfStorageDevices)
                    {
                        uniqueModel.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueMemory.Count < NumberOfStorageDevices)
                    {
                        uniqueMemory.Add(RandomGenerator.GetRandomString(5, 10));
                    }

                    var uniqueVendorList = uniqueVendor.ToList();
                    var uniqueModelList = uniqueModel.ToList();
                    var currentIndex = 0;
                    var deviceType = "HDD";
                    for (int i = 0; i < NumberOfStorageDevices; i++)
                    {
                        if (i == 7)
                        {
                            deviceType = "SSD";
                        }

                        this.AddStorageDevices(db, uniqueVendorList[i], uniqueModelList[i], deviceType, RandomGenerator.GetRandomString(5, 50));

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
                return "Importing Storage Devices";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }

        private void AddStorageDevices(ComputersDbEntities db, string name, string model, string type, string size)
        {
            db.StorageDevices.Add(new StorageDevices
            {
                Vendor = name,
                Model = model,
                Type = type,
                Size = size
            });
        }
    }
}
