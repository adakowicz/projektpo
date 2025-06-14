﻿namespace Parking
{
    internal class Parking
    {
        public Clock Time { get; private set; }
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
            if (pojazd.IsParked == true)
            {
                throw new VehicleAlreadyParkedException("Wybrany pojazd jest już zaparkowany.");
            }
            pojazd.IsParked = true;
            ActualCapacity++;
            if (ActualCapacity > MaximumCapacity)
            {
                ActualCapacity--;
                throw new InvalidCapacityException("Parking jest pełny, nie można dodać pojazdu.");
            }
            else
            {
                pojazd.EntranceTime.Add(new Clock { Day = Time.Day, Hour = Time.Hour, Minute = Time.Minute });
                CarList[pojazd.Registration] = pojazd;
                Raport.AddVehicle(Time.Day, pojazd);
                Time.Tick();
            }
        }

        public void Departure(Vehicle pojazd)
        {
            if (!pojazd.IsParked || pojazd.EntranceTime.Count == pojazd.DepartureTime.Count)
            {
                throw new VehicleAlreadyOutOfParkingException("Nie można wyjechać z parkingu pojazdem, który nie jest na nim zaparkowany.");
            }
            pojazd.IsParked = false;
            pojazd.DepartureTime.Add(new Clock { Day = Time.Day, Hour = Time.Hour, Minute = Time.Minute });
            CarList.Remove(pojazd.Registration);
            ActualCapacity--;

            var czasPostoju = pojazd.DepartureTime[^1] - pojazd.EntranceTime[^1];

            int rozpoczeteGodz = czasPostoju.Hour;
            if (czasPostoju.Minute > 0)
                rozpoczeteGodz += 1;

            int oplata = 0;
            if (pojazd.CarType == CarType.PassengerCar || pojazd.CarType == CarType.DeliveryTruck)
            {
                oplata = 20 * rozpoczeteGodz;
            }
            else
            {
                oplata = 60 * rozpoczeteGodz;
            }

            Console.WriteLine($"Pojazd {pojazd.Registration} opuścił parking. Czas postoju: {czasPostoju.DisplayTime()} - opłata: {oplata} zł");
            Console.WriteLine("Wyjazd zarejestrowany.");
            Time.Tick();
        }

        public void ParkingCurrentStatus()
        {
            Console.WriteLine($"Aktualny czas: {Time.DisplayTime()}");
            Console.WriteLine($"Aktualna liczba pojazdów: {ActualCapacity} na {MaximumCapacity} dostępnych miejsc");
            Console.WriteLine("Lista pojazdów na parkingu:");
            foreach (var vehicle in CarList.Values)
            {
                Console.WriteLine(vehicle.VehicleInfo());
            }
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

        public void ShowDailyRaport(int day)
        {
            Raport.DisplayDailyRaport(day);
        }
    }

        internal class InvalidCapacityException : Exception
        {
            public InvalidCapacityException(string message) : base(message) { }
        }
        internal class VehicleAlreadyParkedException : Exception
        {
            public VehicleAlreadyParkedException(string message) : base(message) { }
        }
        internal class VehicleAlreadyOutOfParkingException : Exception
        {
            public VehicleAlreadyOutOfParkingException(string message) : base(message) { }
        }
        internal class InvalidHourException : Exception
        {
            public InvalidHourException(string message) : base(message) { }
        }
}
