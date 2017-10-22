using System;
using System.Collections.Generic;
using System.Text;

namespace TimetableInterfaces.Models
{
    public class Category
    {
        public Category(int id, string name, int colour)
        {
            CategoryId = id;
            Name = name;
            Colour = colour;
        }


        public int CategoryId { get; set; }
        public int Colour { get; set; }
        public string Name { get; set; }

        
    }
}
