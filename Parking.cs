using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Parking
    {
        private Clock Time;
        private Dictionary<string, Vehicle> CarList;
        private readonly int MaximumCapacity;
        private int ActualCapacity;
        


        public Parking() { }
 
        public void Entrance(Vehicle pojazd)
        {
            CarList[pojazd.Registration] = pojazd;
            pojazd.EntranceTime = Time;
            Time.Tick();
        }
        public void Depature(Vehicle pojazd)
        {
            pojazd.DepatureTime = Time;
            CarList.Remove(pojazd.Registration);
            Time.Tick();
        }
        public

    }
}
