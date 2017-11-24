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

        public Dictionary<int,Event> events = new Dictionary<int, Event>();

        public TimeTableModel(ICalendarService icalendarService, ILogger<TimeTableModel> logger) {

            _icalendarService = icalendarService;
            _logger = logger;
            
        }

        public void OnGet()//az oldal szükséges állapotának inícializálása
        {
            List<Event> localevents = _icalendarService.ListEvents("Adrian");
            
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
                            case 1:
                                events.Add(1, e);
                                break;
                            case 2:
                                events.Add(2, e);
                                break;
                            case 3:
                                events.Add(3, e);
                                break;
                            case 4:
                                events.Add(4, e);
                                break;
                            case 5:
                                events.Add(5, e);
                                break;
                            case 6:
                                events.Add(6, e);
                                break;
                            case 7:
                                events.Add(7, e);
                                break;
                            default:
                                throw new Exception("Nem megfelelő a Nap értéke, csak 1 és 7 közötti érték értelmezhető!");
                        }
                    }
                }
            }
            #endregion
        }

        public List<string> GetDailyEvents(string day) {

            List<string> strlist = new List<string>();

            foreach (KeyValuePair<int, Event> kv in events)
                if (kv.Key.Equals(day))
                    strlist.Add(kv.Value.ToString());

            return strlist;
        }

        public string RenderTableElement(int day, TimeSpan time) {

            string tableElementString = "";

            foreach (KeyValuePair<int, Event> kv in events) {

                TimeSpan CurrentEventStartDate = kv.Value.GetValidEventDate().StartDate;

                if (kv.Key.Equals(day) && CurrentEventStartDate.Equals(time))
                    tableElementString = kv.Value.ToString();
            }

            return tableElementString;
        }

        public string getElementRowSize(int day, TimeSpan time) {
            int rowSize = 1;

            return rowSize.ToString();
        }
    }
}
