using System;
using System.Collections.Generic;
using System.Text;
using TimetableInterfaces.Models;

namespace TimetableInterfaces.Interfaces
{
    public interface ICalendarService
    {
        List<Event> ListEvents(string userName); //az adott felhasználó összes event-jét visszaadja

        bool AddEvent(Event e); // A felhasználó felvehet eseményt

        bool ModifyEvent(Event e); // Adott eseményt felülír

        bool DeleteEvent(int event_id); // törli az adott eseményt

        bool UserLogin(string userName, string password);

        bool AddUser(User u);

        bool ModifyUser(User u);

        bool DeleteUser(string userName);

        List<Event> GenerateNewScheduling(string userName); // újragenerálja az órarendet

        //***********************************
        //------ teszteléshez kellenek ------
        //***********************************
        User GetUser(string username);

        Event GetEvent(int event_id);
    }
}
