using IntergalacticTravel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.MockClasses
{
    public class MockedTeleportStation : TeleportStation
    {
        public MockedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base (owner, galacticMap, location)
        {

        }

        public IBusinessOwner Owner
        {
            get { return base.owner; }
        }

        public ILocation Location
        {
            get { return base.location; }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get { return base.galacticMap; }
        }

        public IResources Resources
        {
            get { return base.resources; }
        }
    }
}
