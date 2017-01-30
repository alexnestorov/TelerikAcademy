using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsApp.Models
{
    public class Producer
    {
        public string Name { get; set; }

        public IEnumerable<string> Models { get; set; }
    }
}