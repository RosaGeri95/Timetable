using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableInterfaces.Models;
using TimetableInterfaces.Interfaces;

namespace TimeTableASP.Pages
{
    public class EventsModel : PageModel
    {

        private readonly ICalendarService _ics;

        public EventsModel(ICalendarService ics)
        {
            _ics = ics;
        }

        public IList<Event> Event { get; set; }

        public void OnGet()
        {
            Event =  _ics.ListEvents("Adrian");
        }
    }
}
