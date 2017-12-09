﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;

namespace TimetableMockService.MockServices
{
    public class MockCalendarService //: ICalendarService
    {
        public List<Event> Events { get; }
        public List<User> Users { get;  }

        public User CurrentUser { get; set; }

        public MockCalendarService()//TODO:Ezt vissza kell írni public-ra éles verziónál
        {
            Events = new List<Event>();
            Users = new List<User>();

            //FillCalendarWithDummyEvents();

        }
        /*
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
            TimeSpan ed0_S = new TimeSpan(14, 0, 0);
            TimeSpan ed0_E = new TimeSpan(14, 30, 0);

            TimeSpan ed1_S = new TimeSpan(8, 0, 0);
            TimeSpan ed1_E = new TimeSpan(11, 30, 0);

            TimeSpan ed2_S = new TimeSpan(12, 0, 0);
            TimeSpan ed2_E = new TimeSpan(14, 0, 0);


            //Events for Gergely
            this.AddEvent(new Event(
                0, Users[0], "Temalabor", "AUT tanszék témalabora","QB202",
                1, category2, ed0_S, ed0_E,1,1
                ));
            this.AddEvent(new Event(
                1, Users[0], "Mobil", "Mobil és webes szoftverek", "IB28",
                3, category1, ed1_S, ed1_E, 3, 0
                ));
            this.AddEvent(new Event(
                2, Users[0], "Szoftvertechnika", "Sznikák cimű tárgy", "Q1",
                2, category3, ed2_S, ed2_E, 5, 2
                ));

            //Events for Adrian
            this.AddEvent(new Event(
                3, Users[1], "Temalabor", "AUT tanszék témalabora", "QB202",
                1, category1, ed0_S, ed0_E, 1, 1
                ));
            this.AddEvent(new Event(
                4, Users[1], "Mobil", "Mobil és webes szoftverek", "IB28",
                3, category3, ed1_S, ed1_E, 3, 0
                ));
            this.AddEvent(new Event(
                5, Users[1], "Szoftvertechnika", "Sznikák cimű tárgy", "Q1",
                2, category2, ed2_S, ed2_E, 5, 2
                ));

        }*/

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
            int deletedItems = Events.RemoveAll(x => (x.ID == event_id) );
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
                if(esemeny.ID == e.ID)
                {
                    found++;
                }
            }
            if(found == 0) { return false; }

            Event evt = Events.First(x => (x.ID == e.ID));
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
                if(e.ID == event_id)
                {
                    return e;
                }
            }
            throw new Exception("Event not found");
        }
        
    }
}
