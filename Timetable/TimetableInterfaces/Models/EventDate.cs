using System;
using System.Collections.Generic;
using System.Text;

namespace TimetableInterfaces.Models
{
    public class EventDate
    {
        private int day;
        private int parity;


        public int EventId { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }

        public int Day
        {
            get { return day; }
            set
            {
                if (value >= 1 && value <= 7)
                {
                    day = value;
                }
                else
                {
                    throw new Exception("Not a valid day!");
                }
            }
        }

        //kérdés: Akkor ha a parity 0 -> minden hét, ha 1 akkor páratlan, ha 2 akkor páros hetek?
        // -1 -et beraktam, ha csak egyszeri alkalommal van az esemény (de ezt kiveheted ha gondolod,
        //nem tudom mennyire bonyolítja a dolgokat)
        public int Parity
        {
            get { return parity; }
            set
            {
                if (value >= -1 && value <= 2)
                {
                    parity = value;
                }
                else
                {
                    throw new Exception("Invalid parity");
                }
            }
        }
    }
}
