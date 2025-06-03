using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Parking
    {
        public Clock Time { get; private set;  }
        private Dictionary<string, Vehicle> CarList;
        private readonly int MaximumCapacity;
        private int ActualCapacity;
        private Raport Raport;

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
            Raport = new Raport();
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
                pojazd.EntranceTime.Add(Time);
                CarList[pojazd.Registration] = pojazd;
                Raport.AddVehicle(Time.Day, pojazd);
                Time.Tick();
            }
        }

        public void Departure(Vehicle pojazd)
        {
            pojazd.DepartureTime.Add(Time);
            CarList.Remove(pojazd.Registration);
            ActualCapacity--;
            var czasPostoju = pojazd.DepartureTime[^1] - pojazd.EntranceTime[^1];
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

        public void ShowHistory()
        {
            Raport.DisplayHistory();
        }

        public void SkipToEndOfDay()
        {
            Time.SkipToEndOfDay();
        }

        public void SkipToHour(int hour)
        {
            Time.SkipToHour(hour);
        }
    }
}
