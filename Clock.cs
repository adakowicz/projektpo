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
        private int Minute;
        private int Hour;
        private int Day;

        public Clock()
        {

        }

        public void Tick()
        {

        }
        public string DisplayTime() => "";

        public static Clock operator -(Clock a, Clock b)
        {
            int resultA = (int)(a.Hour * 60 + a.Day * 24 * 60 + a.Minute);
            int resultB = (int)(b.Hour * 60 + b.Day * 24 * 60 + b.Minute);

            var newClock = new Clock();

            newClock.Minute = resultA - resultB;
        }
    }
}
