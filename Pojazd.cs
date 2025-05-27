using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Vehicle
    {
        public string Registration;
        public string CarType;
        public Clock EntranceTime;
        public Clock DepatureTime;

        public Vehicle() { }

        public string VehicleInfo() => "";

    }
}
