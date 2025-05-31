using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Raport
    {
        private Dictionary<int, List<Vehicle>> DailyRaport;

        public Raport()
        {
            DailyRaport = new Dictionary<int, List<Vehicle>>();
        }

        public void AddVehicle(int Day, Vehicle vehicle)
        {
            if (!DailyRaport.ContainsKey(Day))
            {
                DailyRaport[Day] = new List<Vehicle>();
            }
            DailyRaport[Day].Add(vehicle);
        }

        public void DisplayDailyRaport(int Day)
        {
            if (DailyRaport.ContainsKey(Day))
            {
                Console.WriteLine($"Raport dla dnia {Day}:");
                foreach (var vehicle in DailyRaport[Day])
                {
                    Console.WriteLine(vehicle.VehicleInfo());
                }
            }
            else
            {
                Console.WriteLine($"Brak raportu dla dnia {Day}.");
            }
        }

        public void DisplayHistory()
        {
            foreach (var day in DailyRaport.Keys)
            {
                DisplayDailyRaport(day);
            }
        }     
    }
}