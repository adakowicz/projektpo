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
        private Dictionary<int, List<Vehicle>> Raport;


        public void Tick()
        {
            Time.Tick();
        }

        public Parking()
        {
            Time = new Clock();
            CarList = new Dictionary<string, Vehicle>();
            MaximumCapacity = 50;
            ActualCapacity = 0;
            Raport = new Dictionary<int, List<Vehicle>>();
        }

        public void Entrance(Vehicle pojazd)
        {
            ActualCapacity++;
            if (ActualCapacity > MaximumCapacity)
            {
                ActualCapacity--;
                throw new InvalidCapacityException("Parking jest pełny, nie można wprowadzić pojazdu!");
            }
            else
            {
                pojazd.EntranceTime = Time;
                CarList[pojazd.Registration] = pojazd;
                if (!Raport.ContainsKey(Time.Day))
                {
                    Raport[Time.Day] = new List<Vehicle>();
                }
                Raport[Time.Day].Add(pojazd);
                Time.Tick();
            }
        }

        public void Departure(Vehicle pojazd)
        {
            pojazd.DepartureTime = Time;
            CarList.Remove(pojazd.Registration);
            ActualCapacity--;
            var czasPostoju = pojazd.DepartureTime - pojazd.EntranceTime;
            if (pojazd.CarType == CarType.PassengerCar || pojazd.CarType == CarType.DeliveryTruck)
            {
                int Oplata = 20 * czasPostoju.Hour;
                Console.WriteLine($"Pojazd {pojazd.Registration} opuścił parking. Czas postoju: {czasPostoju} - opłata: {Oplata} zl");
            }
            else
            {
                int OplataT = 60 * czasPostoju.Hour;
                Console.WriteLine($"Pojazd {pojazd.Registration} opuścił parking. Czas postoju: {czasPostoju} - opłata: {OplataT} zl");
            }
            Time.Tick();
        }

        public void ParkingCurrentStatus()
        {
            Console.WriteLine($"Aktualny czas: {Time.DisplayTime()}");
            Console.WriteLine($"Aktualna liczba pojazdów: {ActualCapacity} na {MaximumCapacity} dostepnych miejsc");
            Console.WriteLine("Lista pojazdów na parkingu:");
            foreach (var vehicle in CarList.Values)
            {
                Console.WriteLine(vehicle.VehicleInfo());
            }
        }
        internal class InvalidCapacityException : Exception
        {
            public InvalidCapacityException(string message) : base(message) { }
        }

    }
}
