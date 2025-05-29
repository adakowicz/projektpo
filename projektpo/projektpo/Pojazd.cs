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
        public string Registration;
        public CarType CarType;
        public Clock EntranceTime;
        public Clock DepartureTime;

        public Vehicle(string registration, CarType carType) 
        {
            if(!ValidateRegistration(registration))
            {
                throw new InvalidRegistrationException("Podana rejestra jest błędna!");
            }

            this.Registration = registration;
            this.CarType = carType;
            this.EntranceTime = new Clock();
            this.DepartureTime = new Clock();
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
