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
        private readonly ICalendarService _ics;

        public static int weekParity = 0;

        public Dictionary<int,Event> events = new Dictionary<int, Event>();

        public TimeTableModel(ICalendarService icalendarService) {

            _ics = icalendarService;
            
        }

        public void OnGet()
        {
            List<Event> localevents = _ics.ListEvents("Adrian");
            
            if (weekParity == 0)
                weekParity = 1;
            else if (weekParity == 1)
                weekParity = 2;
            else if (weekParity == 2)
                weekParity = 1;

            #region OrderDays    
            foreach (Event e in localevents)
            {
               
                    if ( e.Parity == weekParity || e.Parity == 0)
                    {
                        switch (e.Day)
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
            #endregion
        }

        public string RenderTableElement(int day, TimeSpan time) {

            string tableElementString = "";

            foreach (KeyValuePair<int, Event> kv in events) {

                if (kv.Key.Equals(day) && kv.Value.StartDate.Equals(time))
                    tableElementString = "Lecture: "+kv.Value.EventName +"   Location: "+ kv.Value.Location;
            }

            return tableElementString;
        }

        public string getElementRowSize(int day, TimeSpan time) {
            int rowSize = 1;

            foreach (KeyValuePair<int, Event> kv in events)
            {

                TimeSpan Diff = new TimeSpan(kv.Value.EndDate.Hours - kv.Value.StartDate.Hours
                                            ,kv.Value.EndDate.Minutes - kv.Value.StartDate.Minutes
                                            , 0);

                if (kv.Key.Equals(day) && kv.Value.StartDate.Equals(time))
                {
                   
                        rowSize = Diff.Hours * 2 + Diff.Minutes / 30;

                }
                    
            }

            return rowSize.ToString();
        }

        public string GetCategoryColor(int day, TimeSpan time) {

            string color = "white";

            foreach (KeyValuePair<int, Event> kv in events)
            {


                if (kv.Key.Equals(day) && kv.Value.StartDate.Equals(time)) {
                    switch (kv.Value.Category.Colour) {
                        case 0:
                            color = "red";
                            break;
                        case 1:
                            color = "green";
                            break;
                        case 2:
                            color = "yellow";
                            break;
                        default:
                            color = "white";
                            break;
                    }
                }
            }

            return color;
        }
    }
}
