using System;

namespace TimetableInterfaces.Models
{
    public class Event
    {
        
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int Priority { get; set; }
        public int Parity { get; set; }
        public int Day { get; set; }

        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }

        public User EventOwner { get; set; }
        public Category Category { get; set; }

    }
}
