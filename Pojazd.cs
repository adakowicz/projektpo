using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

enum CarType
{
    PassengerCar,
    DeliveryTruck,
    Truck
}
namespace Parking
{
    internal class Vehicle
    {
        public string Registration { get; set; }
        public CarType CarType { get; set; }
        public List<Clock> EntranceTime { get; set; }
        public List<Clock> DepartureTime { get; set; }
        public bool IsParked { get; set; }
      
        public Vehicle(string registration, CarType carType) 
        {
            if(!ValidateRegistration(registration))
            {
                throw new InvalidRegistrationException("Podana rejestracja jest błędna!");
            }
            this.IsParked = true;
            this.Registration = registration;
            this.CarType = carType;
            this.EntranceTime = new  List<Clock>();
            this.DepartureTime = new List<Clock>();
        }

        private bool ValidateRegistration(string registration)
        {
            string registrationRegex = @"^[A-Z]{2,3}[0-9A-Z]{4,5}$";
            return Regex.IsMatch(registration, registrationRegex);
        }

        public string VehicleInfo() => $"Rejestracja: {Registration}\nTyp Pojazdu: {CarType}";

    }
    internal class InvalidRegistrationException : Exception
    {
        public InvalidRegistrationException(string message) : base(message) { }
    }
}
