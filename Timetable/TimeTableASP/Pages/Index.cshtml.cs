using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;
using System.Text;
using System.Collections;

namespace TimeTableASP.Pages
{
    public class TimeTableModel : PageModel
    {
        private readonly ICalendarService _icalendarService;

        public Dictionary<string,Event> events;

        public TimeTableModel(ICalendarService icalendarService) {

            _icalendarService = icalendarService;

            events = new Dictionary<string, Event>();
            
        }

        public void OnGet()
        {
            List<Event> localevents = _icalendarService.ListEvents("Adrian");

            #region OrderDays    
            foreach (Event e in localevents)
            {
                foreach (EventDate ed in e.EventDates)
                {
                    if (ed.ChoosenEvent == true)
                    {
                        switch (ed.Day)
                        {
                            case 0:
                                events.Add("Hetfo", e);
                                break;
                            case 1:
                                events.Add("Kedd", e);
                                break;
                            case 2:
                                events.Add("Szerda", e);
                                break;
                            case 3:
                                events.Add("Csutortok", e);
                                break;
                            case 4:
                                events.Add("Pentek", e);
                                break;
                            case 5:
                                events.Add("Szombat", e);
                                break;
                            case 6:
                                events.Add("Vasarnap", e);
                                break;
                            default:
                                throw new Exception("Nem megfelelő a Nap értéke!");
                        }
                    }
                }
            }
            #endregion
        }

        public List<string> GetDailyEvents(string day) {

            List<string> strlist = new List<string>();

            foreach (KeyValuePair<string, Event> kv in events)
                if (kv.Key.Equals(day))
                    strlist.Add(kv.Value.ToString());

            return strlist;
        }
    }
}
