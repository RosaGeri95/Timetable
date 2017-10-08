using System;
using System.Collections.Generic;
using System.Text;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;

namespace TimetableService.Service
{
    public class CalendarService : ICalendarService
    {
        public CalendarService()
        {
        }

        public bool AddEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User u)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int event_id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Event> GenerateNewScheduling(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Event> ListEvents(string userName)
        {
            throw new NotImplementedException();
        }

        public bool ModifyEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public bool ModifyUser(User u)
        {
            throw new NotImplementedException();
        }

        public User UserLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
