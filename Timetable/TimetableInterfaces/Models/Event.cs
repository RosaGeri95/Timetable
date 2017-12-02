using System;
using System.Text;


namespace TimetableInterfaces.Models
{
    //[Table("Termek")]
    public class Event
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public User EventOwner { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Priority { get; set; }
        public Category Category { get; set; }
        public int Parity { get; set; }
        public int Day { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }

        public Event() {
            EventOwner = new User("NULL","PASS",new DateTime());
            Category = new Category();
            StartDate = new TimeSpan(8, 0, 0);
            EndDate = new TimeSpan(8, 30, 0);
        }

        public Event(int eventID, User owner, string eventName, string desc, string loc, int priority,
            Category cat, TimeSpan startDate, TimeSpan endDate, int day, int parity)
        {
            EventId = eventID;
            EventOwner = owner;
            EventName = eventName;
            Description = desc;
            Location = loc;
            Priority = priority;
            Category = cat;
            StartDate = startDate;
            EndDate = endDate;
            Day = day;
            Parity = parity;
        }

     


        public override bool Equals(object obj)
        {
            Event other = (Event) obj;
            return this.EventId == other.EventId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



        public override string ToString()
        {
            StringBuilder times = new StringBuilder();
            
                
                    times.Append("Week parity: ");
                    times.Append(Parity.ToString());
                    times.Append(", Day number: ");
                    times.Append(Day.ToString());
                    times.Append(", Time: ");
                    times.Append(StartDate.ToString());
                    times.Append(" - ");
                    times.Append(EndDate.ToString());
                    times.Append("\t");
                
            

            return "Name of Event: " + EventName + "\n"
                + "Owner: " + EventOwner.Username + "\n"
                + "Location: " + Location + "\n"
                + "Description: " + Description + "\n"
                + "Due Times: " + times.ToString() + "\n"
                + "Category: " + Category.Name + "\n";
        }
    }
}
