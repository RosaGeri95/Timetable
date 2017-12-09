using System.Collections.Generic;

namespace TimetableInterfaces.Models
{
    public class Category
    {

        public int CategoryID { get; set; }
        public int Colour { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}
