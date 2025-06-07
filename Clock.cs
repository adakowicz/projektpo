namespace Parking
{
    internal class Clock
    {

        public int Minute;
        public int Hour;
        public int Day;

        public Clock()
        {
            Minute = 0;
            Hour = 6;
            Day = 1;

        }

        public void Tick()
        {
            Minute += 15;
            if (Minute >= 60)
            {
                Minute = 0;
                Hour++;
                if (Hour >= 22)
                {
                    Hour = 6;
                    Day++;
                }
            }
        }
        public string DisplayTime()
        {
            return $"Dzień {Day} {Hour:D2}:{Minute:D2}";
        }

        public int RoznicaMinut(Clock other)
        {
            int minuty1 = (Day - 1) * 16 * 60 + (Hour - 6) * 60 + Minute;
            int minuty2 = (other.Day - 1) * 16 * 60 + (other.Hour - 6) * 60 + other.Minute;

            return minuty1 - minuty2;
        }

        public static Clock operator -(Clock a, Clock b)
        {
            int totalMinutesA = ((a.Day - 1) * 24 + a.Hour) * 60 + a.Minute;
            int totalMinutesB = ((b.Day - 1) * 24 + b.Hour) * 60 + b.Minute;
            int diffMinutes = totalMinutesA - totalMinutesB;
            int days = diffMinutes / (24 * 60) + 1;
            int hours = (diffMinutes % (24 * 60)) / 60;
            int minutes = diffMinutes % 60;

            return new Clock
            {
                Day = days,
                Hour = hours,
                Minute = minutes
            };
        }

        public void SkipToEndOfDay()
        {
            while (!(Hour == 21 && Minute == 45))
            {
                Tick();
            }
        }

        public void SkipToHour(int targetHour)
        {
            if (targetHour < Hour || targetHour > 21)
            {
                throw new InvalidHourException("Nieprawidłowa godzina - można przesunąć tylko między 6 a 21.");
            }

            while (Hour < targetHour)
            {
                Tick();
            }
        }
    }
}
