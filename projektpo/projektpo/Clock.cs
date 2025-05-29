using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            return $"Dzień {Day} {Hour}:{Minute}";
        }

        public static Clock operator -(Clock a, Clock b)
        {
            int resultA;
            if (a.Minute > 0) resultA = a.Hour + (a.Day - 1) * 16 + 1;
            else resultA = a.Hour + (a.Day - 1) * 16;
            int resultB;
            if (b.Minute > 0) resultB = (int)(b.Hour + (b.Day - 1) * 16 + b.Minute);
            else resultB = (int)(b.Hour + (b.Day - 1) * 16);

            var newClock = new Clock();
            newClock.Hour = resultA - resultB;
            
            return newClock;
        }
    }
}
