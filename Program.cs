using System;
using System.Collections.Generic;

namespace Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witamy w systemie parkingowym!");
            List<Vehicle> pojazdy = new List<Vehicle>();
            int wybranyPojazd = -1;
            Parking parking = new Parking();
            
        start:
        Console.WriteLine($"\nAktualny czas: {parking.Time.DisplayTime()}");
            Console.WriteLine($"" +
                $"1. Dodaj pojazd\n" +
                $"2. Wybierz pojazd\n" +
                $"3. Wjedź na parking\n" +
                $"4. Wyjedź z parkingu\n" +
                $"5. Wyświetl historię pojazdu\n" +
                $"6. Wyświetl całą historię parkingu\n" +
                $"7. Przesuń czas\n" +
                $"8. Zmiana godziny lub zakończenie dnia\n" +
                $"9 Zakończ działanie programu.");
                
            Console.Write("Wybór: ");
            string? wybor = Console.ReadLine();
            Console.WriteLine();
            
            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj numer rejestracyjny: ");
                    string? rejestracja = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(rejestracja))
                    {
                        Console.WriteLine("Rejestracja nie może być pusta!");
                        goto start;
                    }

                    Console.WriteLine("Typ pojazdu: 0 - Osobowy, 1 - Dostawczy, 2 - Ciężarowy");
                    if (!int.TryParse(Console.ReadLine(), out int typ) || typ < 0 || typ > 2)
                    {
                        Console.WriteLine("Nieprawidłowy typ.");
                        goto start;
                    }

                    try
                    {
                        Vehicle nowy = new Vehicle(rejestracja, (CarType)typ);
                        pojazdy.Add(nowy);
                        Console.WriteLine("Pojazd dodany.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd: {ex.Message}");
                    }
                    goto start;

                case "2":
                    if (pojazdy.Count == 0)
                    {
                        Console.WriteLine("Brak pojazdów do wyboru.");
                        goto start;
                    }

                    Console.WriteLine("Lista pojazdów: ");
                    for (int i = 0; i < pojazdy.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {pojazdy[i].VehicleInfo()}");
                    }

                    Console.WriteLine("Wybierz pojazd: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < pojazdy.Count)
                    {
                        wybranyPojazd = index;
                        Console.WriteLine("Pojazd wybrany.");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy wybór.");
                    }
                    goto start;

                case "3":
                    if (wybranyPojazd == -1)
                    {
                        Console.WriteLine("Nie wybrano pojazdu.");
                        goto start;
                    }

                    try
                    {
                        parking.Entrance(pojazdy[wybranyPojazd]);
                        Console.WriteLine("Wjazd zarejestrowany.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    goto start;

                case "4":
                    if (wybranyPojazd == -1)
                    {
                        Console.WriteLine("Nie wybrano pojazdu.");
                        goto start;
                    }

                    parking.Departure(pojazdy[wybranyPojazd]);
                    goto start;

                case "5":
                    if (wybranyPojazd == -1)
                    {
                        Console.WriteLine("Nie wybrano pojazdu.");
                        goto start;
                    }

                    var pojazd = pojazdy[wybranyPojazd];
                    Console.WriteLine("Historia pojazdu:");
                    for (int i = 0; i < pojazd.EntranceTime.Count; i++)
                    {
                        string wyj = i < pojazd.DepartureTime.Count ? pojazd.DepartureTime[i].DisplayTime() : "Pojazd jest stoi na parkingu.";
                        Console.WriteLine($"Wjazd: {pojazd.EntranceTime[i].DisplayTime()} - Wyjazd: {wyj}");
                    }
                    goto start;

                case "6":
                    parking.ParkingCurrentStatus();
                    goto start;

                case "7":
                    parking.Tick();
                    Console.WriteLine("Czas przesunięty.");
                    goto start;

                case "8":
                    Console.WriteLine("1. Przesuń czas do końca dnia.");
                    Console.WriteLine("2. Przesuń czas na konkretną godzinę");
                    string? opcja = Console.ReadLine();

                    if (opcja == "1")
                    {
                        parking.SkipToEndOfDay();
                        Console.WriteLine("Przesunięto czas do końca dnia.");
                    }
                    else if (opcja == "2")
                    {
                        Console.WriteLine("Podaj wybraną godzinę: ");
                        if (int.TryParse(Console.ReadLine(), out int godzina))
                        {
                            parking.SkipToHour(godzina);
                            Console.WriteLine($"Czas przesunięty na godzinę {godzina}:00.");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowa godzina.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa opcja.");
                    }
                    goto start;

                case "9":
                    Console.WriteLine("Zamykanie programu.");
                    break;

                default:
                    Console.WriteLine("Proszę wybrać opcję od 1 do 9,.");
                    goto start;

            }

            Vehicle car1 = new Vehicle("ABC1234", CarType.PassengerCar);
            Console.WriteLine(car1.VehicleInfo());
        }
    }
}
