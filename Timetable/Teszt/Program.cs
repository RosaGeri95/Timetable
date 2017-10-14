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
            MockCalendarService mcs = (MockCalendarService)mcsf.CreateCalendarService("MCS");


            foreach (User usr in mcs.Users)
            {
                Console.WriteLine(usr);
            }

            List<Event> gergelyEvents = mcs.ListEvents("Gergely");
            List<Event> adrianEvents = mcs.ListEvents("Adrian");

            Console.WriteLine("\n *********************** \n");
            Console.WriteLine("Gergely eseményei:\n");
            foreach (Event e in gergelyEvents)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n *********************** \n");
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Adrian eseményei:\n");

            foreach (Event e in adrianEvents)
            {
                Console.WriteLine(e.ToString());
            }


            Console.WriteLine("\n---------------------");
            Console.WriteLine("Event hozzáadásának kipróbálása");

            EventDate ed6 = new EventDate(6,
               new TimeSpan(7, 0, 0), new TimeSpan(12, 0, 0), 6, 0);

            //add dates to list
            List<EventDate> dates6 = new List<EventDate>
            {
                ed6
            };

            //ilyen eventID már van
            if (mcs.AddEvent(new Event(1, mcs.GetUser("Gergely"),
                "Proba", "Csak kiprobalasra", "Ib25", 2, new Category(5, "Valami", 2),
                dates6)))
            {
                Console.WriteLine("EventFirst added");
            }

            //ilyen eventID még nincs
            if (mcs.AddEvent(new Event(7, mcs.GetUser("Gergely"),
                "Proba", "Csak kiprobalasra", "Ib25", 2, new Category(5, "Valami", 2),
                dates6)))
            {
                Console.WriteLine("EventSecond added");
            }

            //----------Felhasználó hozzáadása--------------

            //Nem létező user hozzáadása
            if (mcs.AddUser(new User("Peti", "asd", new DateTime())))
            {
                Console.WriteLine("Peti user added");
            }
            //már létező user hozzáadása
            if (mcs.AddUser(new User("Gergely", "dsa", new DateTime())))
            {
                Console.WriteLine("Ezt nem kellene kiirnia");
            }

            //--------- event törlése ---------------
            //van ilyen event
            if (mcs.DeleteEvent(1))
            {
                Console.WriteLine("Event 1 deleted!");
            }
            //nincs ilyen event
            if (mcs.DeleteEvent(98))
            {
                Console.WriteLine("Event 98 deleted!");
            }

            //-------- user törlése ------ 
            //nem létező felhasználó, ne irja ki
            if (mcs.DeleteUser("asdasd"))
            {
                Console.WriteLine("User asdasd letörölve");
            }
            //létező felhasználó
            if (mcs.DeleteUser("Adrian"))
            {
                Console.WriteLine("User Adrian letörölve");
            }


            //---------------Event módosítása ------------
            //létező event
            Event e1 = mcs.GetEvent(0);
            e1.Category = new Category(89, "Csere", 45);
            e1.EventName = "T-lab";
            e1.Description = "AUT";
            EventDate newDate = new EventDate(0,
               new TimeSpan(7, 7, 7), new TimeSpan(12, 12, 12), 7, 2);
            e1.EventDates.Add(newDate);
            if (mcs.ModifyEvent(e1))
            {
                Console.WriteLine("Témalabor event cserelve!");
            }

            //nem létező event
            Event e2 = new Event(28, mcs.GetUser("Gergely"),
                "P", "kiprobalasra", "Ib225", 1, new Category(53, "V", 6),
                dates6);
            if (mcs.ModifyEvent(e2))
            {
                Console.WriteLine("Nem irja ki, mert nem létező eventet nem lehet módosítani");
            }


            //------------- User módsítás---------
            //létező felhasználó
            User u1 = mcs.GetUser("Gergely");
            u1.Password = "asd123";
            if (mcs.ModifyUser(u1))
            {
                Console.WriteLine("Gergely jelszava megváltozott");
            }
            //nem létező felhasználót nem lehet modosítani (ne irja ki)
            User u2 = new User("Jani", "lol", new DateTime());
            if (mcs.ModifyUser(u2))
            {
                Console.WriteLine("Jani felhasználó nem létezik");
            }

            //--------LOGIN ---------------
            //létező felhasználó és jelszó
           if(mcs.UserLogin("Gergely", "asd123"))
            {
                Console.WriteLine("Gergely logged in");
            }
           //jó username, rossz password
           if( ! (mcs.UserLogin("Gergely", "pw123")))
            {
                Console.WriteLine("Wrong password for Gergely");
            }
           //rossz username és password
           if(mcs.UserLogin("fsadsadsa", "dsafafa"))
            {
                Console.WriteLine("Ezt már nem irja ki");
            }

           //Események kilistázása
            Console.WriteLine("\n\n");
            Console.WriteLine("*********************** \n");

            foreach (Event evt in mcs.Events)
            {
                Console.WriteLine(evt);
            }

            Console.WriteLine("\n *********************** \n");
            //felhasználók listázása
            foreach (User usr in mcs.Users)
            {
                Console.WriteLine(usr);
            }

            Console.ReadLine();
        }
    }
}
