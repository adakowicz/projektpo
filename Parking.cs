namespace Parking
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
            if (pojazd.CarType == CarType.Truck)
            {
                if (ActualCapacity + 3 > MaximumCapacity)
                {
                    throw new InvalidCapacityException("Parking jest pełny, nie można dodać pojazdu.");
                }
                else
                {
                    ActualCapacity += 3;
                    pojazd.IsParked = true;
                }
            }
            else
            {
                if (ActualCapacity + 1 > MaximumCapacity)
                {
                    throw new InvalidCapacityException("Parking jest pełny, nie można dodać pojazdu.");
                }
                else
                {
                    ActualCapacity++;
                    pojazd.IsParked = true;
                }
            }
            if (pojazd.IsParked == true)
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
            if (pojazd.CarType == CarType.Truck)
            {
                ActualCapacity -= 3;
            }
            else
            {
                ActualCapacity--;
            }

            var czasPostoju = pojazd.DepartureTime[^1] - pojazd.EntranceTime[^1];

            if (pojazd.CarType == CarType.PassengerCar || pojazd.CarType == CarType.DeliveryTruck)
            {
                int Oplata = 20 * czasPostoju.Hour;
                Console.WriteLine($"Pojazd {pojazd.Registration} opuścił parking. Opłata za postoj: {Oplata} zl");
            }
            else
            {
                int OplataT = 60 * czasPostoju.Hour;
                Console.WriteLine($"Pojazd {pojazd.Registration} opuścił parking. Opłata za postoj: {OplataT} zl");
            }
            Console.WriteLine("Wyjazd zarejestrowany.");
            Time.Tick();
        }

        public void ParkingCurrentStatus()
        {
            Console.WriteLine($"Aktualny czas: {Time.DisplayTime()}");
            Console.WriteLine($"Dostepne miejsca: {MaximumCapacity-ActualCapacity} na {MaximumCapacity}");
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
