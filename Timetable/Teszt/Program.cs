using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;

namespace Teszt
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            MockCalendarService mcs = (MockCalendarService) mcsf.CreateCalendarService("MCS");

            List<Event> gergelyEvents = mcs.ListEvents("Gergely");
            List<Event> adrianEvents = mcs.ListEvents("Adrian");

            Console.WriteLine("Gergely eseményei:");
            foreach(Event e in gergelyEvents)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n---------------------");
            Console.WriteLine("Adrian eseményei:");

            foreach (Event e in adrianEvents)
            {
                Console.WriteLine(e.ToString());
            }


            Console.ReadLine();

        }
    }
}
