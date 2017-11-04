using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;

namespace TimetableMockService.MockServices
{
    public class MockCalendarService : ICalendarService
    {
        public List<Event> Events { get; }
        public List<User> Users { get;  }

        public User CurrentUser { get; set; }

        public MockCalendarService()
        {
            Events = new List<Event>();
            Users = new List<User>();

            FillCalendarWithDummyEvents();

        }

        private void FillCalendarWithDummyEvents()
        {
            //Users
            User geri = new User("Gergely", "pw123", new DateTime());
            this.AddUser(geri);
            CurrentUser = geri;
            this.AddUser(new User("Adrian", "pw789", new DateTime()));

            //Categories

            Category category1 = new Category(0, "Other", 0);
            Category category2 = new Category(1, "Lecture", 1);
            Category category3 = new Category(2, "Exam", 2);

            //EventDates for "Gergely"
            EventDate ed0 = new EventDate(0,
                new TimeSpan(14, 0, 0), new TimeSpan(14, 20, 0), 1, 2, true);
            EventDate ed1 = new EventDate(1,
                new TimeSpan(10, 0, 0), new TimeSpan(14, 0, 0), 2, 1, true);
            EventDate ed12 = new EventDate(1,
                new TimeSpan(15, 0, 0), new TimeSpan(17, 0, 0), 4, 2, false);
            EventDate ed2 = new EventDate(2,
                new TimeSpan(9, 0, 0), new TimeSpan(11, 20, 0), 3, 0, true);

            //EventDates for "Adrian"
            EventDate ed3 = new EventDate(3,
                new TimeSpan(14, 0, 0), new TimeSpan(14, 20, 0), 1, 2, true);
            EventDate ed4 = new EventDate(4,
                new TimeSpan(10, 0, 0), new TimeSpan(14, 0, 0), 2, 1, true);
            EventDate ed42 = new EventDate(4,
                new TimeSpan(15, 0, 0), new TimeSpan(17, 0, 0), 4, 2, false);
            EventDate ed5 = new EventDate(5,
                new TimeSpan(9, 0, 0), new TimeSpan(11, 20, 0), 3, 0, true);

            //add dates to list
            List<EventDate> dates0 = new List<EventDate>
            {
                ed0
            };
            List<EventDate> dates1 = new List<EventDate>
            {
                ed1,
                ed12
            };
            List<EventDate> dates2 = new List<EventDate>
            {
                ed2
            };

            List<EventDate> dates3 = new List<EventDate>
            {
                ed3
            };
            List<EventDate> dates4 = new List<EventDate>
            {
                ed4,
                ed42
            };
            List<EventDate> dates5 = new List<EventDate>
            {
               ed5
            };


            //Events for Gergely
            this.AddEvent(new Event(
                0, Users[0], "Temalabor", "AUT tanszék témalabora","QB202",
                1, category2, dates0
                ));
            this.AddEvent(new Event(
                1, Users[0], "Mobil", "Mobil és webes szoftverek", "IB28",
                3, category2, dates1
                ));
            this.AddEvent(new Event(
                2, Users[0], "Szoftvertechnika", "Sznikák cimű tárgy", "Q1",
                2, category2, dates2
                ));

            //Events for Adrian
            this.AddEvent(new Event(
                3, Users[1], "Temalabor", "AUT tanszék témalabora", "QB202",
                1, category2, dates3
                ));
            this.AddEvent(new Event(
                4, Users[1], "Mobil", "Mobil és webes szoftverek", "IB28",
                3, category2, dates4
                ));
            this.AddEvent(new Event(
                5, Users[1], "Szoftvertechnika", "Sznikák cimű tárgy", "Q1",
                2, category2, dates5
                ));

        }

        public bool AddEvent(Event e)
        {
            if (Events.Contains(e))
            {
                return false;
            }
            Events.Add(e);
            
            return true;
        }

        public bool AddUser(User u)
        {
            if (Users.Contains(u))
            {
                return false;
            }
            Users.Add(u);
            return true;
        }

        public bool DeleteEvent(int event_id)
        {
            int deletedItems = Events.RemoveAll(x => (x.EventId == event_id) );
            if(deletedItems > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(string userName)
        {
            Events.RemoveAll(x => (x.EventOwner.Username == userName) );

            int deletedUser = Users.RemoveAll(y => (y.Username == userName) );
            if(deletedUser > 0)
            {
                return true;
            }
            return false;
        }


        //Ezt majd később
        public List<Event> GenerateNewScheduling(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Event> ListEvents(string userName)
        {
            List<Event> resultList = new List<Event>();
            foreach(Event e in Events)
            {
                if(e.EventOwner.Username == userName)
                {
                    resultList.Add(e);
                }
            }
            return resultList;
        }

        public bool ModifyEvent(Event e)
        {
            int found = 0;
            foreach(Event esemeny in Events)
            {
                if(esemeny.EventId == e.EventId)
                {
                    found++;
                }
            }
            if(found == 0) { return false; }

            Event evt = Events.First(x => (x.EventId == e.EventId));
            var index = Events.IndexOf(evt);

            if(index != -1)
            {
                Events[index] = e;
                return true;
            }
            return false;
        }

        public bool ModifyUser(User u)
        {
            int found = 0;
            foreach (User user in Users)
            {
                if (user.Username == u.Username)
                {
                    found++;
                }
            }
            if (found == 0) { return false; }

            User usr = Users.First(x => (x.Username == u.Username));
            var index = Users.IndexOf(usr);

            if (index != -1)
            {
                Users[index] = u;
                return true;
            }
            return false;
        }

        public bool UserLogin(string userName, string password)
        {
            foreach(User user in Users)
            {
                if( (user.Username == userName) && (user.Password == password) )
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        //***********************************
        //------ teszteléshez kellenek ------
        //***********************************
        public User GetUser(string username)
        {
            foreach(User user in Users)
            {
                if(user.Username == username)
                {
                    return user;
                }
            }
            throw new Exception("User not found");
        }

        public Event GetEvent(int event_id)
        {
            foreach(Event e in Events)
            {
                if(e.EventId == event_id)
                {
                    return e;
                }
            }
            throw new Exception("Event not found");
        }
        
    }
}
