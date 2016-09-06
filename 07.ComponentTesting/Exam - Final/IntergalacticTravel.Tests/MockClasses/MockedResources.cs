using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.MockClasses
{
    public class MockedResources : Resources
    {
        public MockedResources(uint bronzeCoins, uint silverCoins, uint goldCoins) 
            : base (bronzeCoins, silverCoins, goldCoins)
        {

        }
    }
}
