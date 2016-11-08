using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Data;

namespace Computers.Importer.Importers
{
    public class CPUsImporter : IImporter
    {
        private const int NumberOfCPUs = 10;

        public Action<ComputersDbEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var uniqueVendor = new HashSet<string>();
                    var uniqueModel = new HashSet<string>();

                    while (uniqueVendor.Count < NumberOfCPUs)
                    {
                        uniqueVendor.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    while (uniqueModel.Count < NumberOfCPUs)
                    {
                        uniqueModel.Add(RandomGenerator.GetRandomString(5, 50));
                    }

                    var uniqueVendorList = uniqueVendor.ToList();
                    var uniqueModelList = uniqueModel.ToList();
                    var currentIndex = 0;

                    for (int i = 0; i < NumberOfCPUs; i++)
                        {
                            this.AddCPUs(db, uniqueVendorList[i], uniqueModelList[i], RandomGenerator.GetRandomNumber(2,8), RandomGenerator.GetRandomString(5,50));

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
                return "Importing CPUs";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        private void AddCPUs(ComputersDbEntities db, string name, string model, int cores, string clockCycles)
        {
            db.CPUs.Add(new CPUs
            {
                Vendor = name,
                Model = model,
                NumberOfCores = cores,
                ClockCycles = clockCycles
            });
        }
    }
}
