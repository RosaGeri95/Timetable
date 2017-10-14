using System;
using System.Collections.Generic;
using System.Text;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;

namespace TimetableMockService.MockServices
{
    public class MockCalendarService : ICalendarService
    {
        public IList<Event> Events { get;}
        public IList<User> Users { get; }

        public User CurrentUser { get; set; }

        public MockCalendarService()
        {
            Events = new List<Event>();
            Users = new List<User>();

            FillCalendarWithDummyEvents();
        }

        private void FillCalendarWithDummyEvents()
        {
            this.AddUser(new User("Gergely", "pw123", new DateTime()));
            this.AddUser(new User("Adrian", "pw789", new DateTime()));

            //Eventek majd később
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
            foreach(Event e in Events)
            {
                if(e.EventId == event_id)
                {
                    Events.Remove(e);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteUser(string userName)
        {
            foreach (User u in Users)
            {
                if (u.Username == userName)
                {
                    Users.Remove(u);
                    return true;
                }
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
            foreach(Event evt in Events)
            {
                //ID-jukat hasonlítja össze (Equals() metódus)
                if (evt  == e)
                {
                    Events.Remove(evt);
                    Events.Add(e);
                    return true;
                }
            }
            return false;
        }

        public bool ModifyUser(User u)
        {
            foreach(User user in Users)
            {
                if(user == u)
                {
                    Users.Remove(user);
                    Users.Add(u);
                    return true;
                }
            }
            return false;
        }

        public User UserLogin(string userName, string password)
        {
            foreach(User user in Users)
            {
                if( (user.Username == userName) && (user.Password == password) )
                {
                    CurrentUser = user;
                    return CurrentUser;
                }
            }
            return null;
        }
    }
}
