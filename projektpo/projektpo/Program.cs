using System;
namespace Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car1 = new Vehicle("ABC1234", CarType.PassengerCar);
            Console.WriteLine(car1.VehicleInfo());
        }
    }
}
