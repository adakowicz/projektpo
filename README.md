# Symulator Parkingu

## Cel projektu
Głównym celem projektu było stworzenie konsolowej aplikacji, która będzie symulowała system obsługi parkingu, czyli np. kontrolowała liczbę dostępnych miejsc, generowała raporty, naliczała opłaty za postój.
Język jakim się posługiwaliśmy to C#.

## Funkcje
- Dodawanie pojazdów
- Wybór pojazdu
- Obsługa różnych typów pojazdów: samochód osobowy, dostawczy i ciężarówka
- Wjazd na parking
- Wyjazd z parkingu
- Naliczanie opłat za każdą rozpoczętą godzinę
- Wyświetlanie historii pojazdu
- Ograniczona liczba miejsc
- Wyświetlanie całej historii parkingu (od dnia pierwszego do obecnego)
- Wyświetlanie raportu dziennego (z możliwością wyboru konkretnego dnia, który nas interesuje)
- Przesunięcie czasu
- Zmiana godziny na wybraną
- Możliwość zakończenia dnia
- Zakończenie działania programu

## Pliki
- Program.cs - menu użytkownika
- Parking.cs - obsługa wjazdów, wyjazdów, raportów i opłat
- Raport.cs - historia parkingu i raporty dzienne
- Clock.cs - symulacja czasu
- Pojazd.cs - klasa odpowiedzialna za konkretny pojazd, jego wjazdy i wyjazdy

## Sposób uruchomienia
    1. Należy otworzyć projekt w wybranym środowisku np. Visual Studio Code
    2. Sprawdzić czy w projekcie są umieszczone wszystkie wyżej wymienione pliki
    3. Skompilować (Ctrl+Shift+B)
    4. Uruchomić program za pomocą F5, przycisku start lub komendy "dotnet run" w terminalu
    5. Dalej należy iść zgodnie z instrukcjami, które są wyświetlone w konsoli

## Sposób przykładowego użycia
- Dodanie pojazdu poprzez wpisanie jego numeru rejestracyjnego
- Wybranie pojazdu z przedstawionej listy
- Wjazd wybranego pojazdu na parking
- Zmiana czasu 
- Wyjazd danego pojazdu
- Wyświetlenie komunikatu o wysokości opłaty i czasie postoju (dzieje się to automatycznie)
- Wygenerowanie wybranego raportu
- Zamknięcie programu

## Uwagi
- Parking działa w godzinach 06:00-22:00
- Numer rejestracyjny należy wpisywać w postaci: 2/3 wielkich liter i 4/5 znaków, które mogą być wielkimi literami bądź cyframi, bez spacji
- Czas jest przesuwany o domyślne 15 minut
- Opłata jest naliczana za każdą rozpoczętą godzinę: samochód osobowy i dostawczy 20zł, ciężarówka 60 zł
- Liczba miejsc jest ograniczona do 50

## Podsumowanie
Projekt został stworzony w celu symulacji systemu obsługi parkingu. Aby pokazać stopień przyswojenia wiedzy z zakresu programowania obiektowego użyliśmy:
- struktury danych tj. lista, słownik
- obsługi wyjatków
- wyboru opcji
- walidacji danych
- interfejsu tekstowego
- symulacji czasu
- przeciążenia operatora
Jako relacji między klasami użyliśmy: agregacji, kompozycji i dziedziczenia.

## Autorzy
- Oliwia Banachowska
- Amelia Dakowicz
- Maciej Klepacki
