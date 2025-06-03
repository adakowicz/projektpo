using System;
namespace Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witamy");
            List<Vehicle> pojazdy = new List<Vehicle>();
            int wybranyPojazd = 0;
            Parking parking = new Parking()
            Vehicle actualVehicle = ;
        start:
            Console.WriteLine($"" +
                $"1. Dodaj Pojazd\n" +
                $"2. Wybierz Pojazd\n" +
                $"3. Wjedz na parking\n" +
                $"4. Wyjedz z parkingu\n" +
                $"5. Wyswietl historie pojazdu\n" +
                $"6. Wyswietl historie (calego) parkingu\n" +
                $"7. Przesun czas" +
                $"8. Zacznij nowy dzien" +
                $"9 Zakoncz dzialanie programu");
                
            string wybor = Console.ReadLine();
            switch(wybor)
            {
                case "1":
                    goto start;
                case "2":

                    goto start;
                case "3":
                    goto start;
                case "4":
                    goto start;
                case "5":
                    goto start;
                case "6":
                    goto start;
                case "7":
                    goto start;
                case "8":
                    goto start;
                case "9":
                    break;
                default:
                    Console.WriteLine("Prosze wybrac przyciski od 1-9");
                    goto start;

            }



            Vehicle car1 = new Vehicle("ABC1234", CarType.PassengerCar);
            Console.WriteLine(car1.VehicleInfo());
        }
    }
}
