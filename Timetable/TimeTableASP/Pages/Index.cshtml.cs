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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TimeTableASP.Pages
{
    public class TimeTableModel : PageModel
    {
        private readonly ICalendarService _icalendarService;
        private readonly ILogger _logger;

        public static int weekParity = 0;

        public Dictionary<string,Event> events = new Dictionary<string, Event>();

        public TimeTableModel(ICalendarService icalendarService, ILogger<TimeTableModel> logger) {

            _icalendarService = icalendarService;
            _logger = logger;
            
        }

        public void OnGet()//az oldal szükséges állapotának inícializálása
        {
            List<Event> localevents = _icalendarService.ListEvents("Adrian");
            _logger.LogDebug(50000, new Exception(), "\n--------------OnGet()-----------\n");
            
            if (weekParity == 0)
                weekParity = 1;
            else if (weekParity == 1)
                weekParity = 2;
            else if (weekParity == 2)
                weekParity = 1;

            #region OrderDays    
            foreach (Event e in localevents)
            {
                foreach (EventDate ed in e.EventDates)
                {
                    if (ed.ChoosenEvent == true && (ed.Parity == weekParity || ed.Parity == 0))
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

        public string RenderTableElement(int day, TimeSpan time) {            
            return "*";
        }

        public string getElementRowSize(int day, TimeSpan time) {
            return "1";
        }
    }
}
