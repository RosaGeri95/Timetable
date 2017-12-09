using System;
using System.Collections.Generic;
using TimetableInterfaces.Models;
using TimetableInterfaces.Interfaces;
using TimeTableASP;

namespace TimetableService.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly TimeTableContext _db;

        public CalendarService(TimeTableContext db)
        {
            _db = db;
        }

        public bool AddEvent(Event e,string UserName,string Category)
        {
            using (_db) {

                var categories = _db.Categories;

                foreach (Category c in categories)
                    if (c.Name.Equals(Category))
                        e.CategoryID = c.CategoryID;

                var users = _db.Users;

                foreach (User u in users)
                    if (u.Username.Equals(UserName))
                        e.UserID = u.ID;
            

                _db.Add(e);
                    if(_db.SaveChanges()>0)
                    return true;

                return false;
            }
        }

        public bool AddUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int event_id)
        {
            using (_db) {

               Event e = _db.Events.Find(event_id);

                if (e != null)
                {
                    _db.Remove(e);
                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Event> GenerateNewScheduling(string userName)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int event_id)
        {
            using (_db)
            {

                Event e = _db.Events.Find(event_id);
                var Categories = _db.Categories;
                var Users = _db.Users;

                foreach (var u in Users)
                    if (u.ID == e.ID)
                        e.EventOwner = u;

                foreach (var c in Categories)
                    if (c.CategoryID == e.CategoryID)
                        e.Category = c;


                if (e != null)
                {
                    return e;
                }

                throw new NullReferenceException();
            }
        }

        public User GetUser(string username)
        {
            using (_db)
            {
                var users = _db.Users;

                foreach (User u in users)
                    if (u.Username.Equals(username))
                        return u;

                throw new NullReferenceException();
            }
        }

        public List<Event> ListEvents(string UserName)
        {
            List<Event> localEventList = new List<Event>();

            using (_db)
            {
                var Events = _db.Events;
                var Categories = _db.Categories;

                foreach (var e in Events) {
                    foreach (var c in Categories) {
                        if (c.CategoryID == e.CategoryID)
                            e.Category = c;
                            
                    }
                        localEventList.Add(e);
                }

                return localEventList;
            }

        }

        public bool ModifyEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public bool ModifyUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool UserLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
