using System;
using System.Collections.Generic;

namespace TimetableInterfaces.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime ParitySourceDate { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}







