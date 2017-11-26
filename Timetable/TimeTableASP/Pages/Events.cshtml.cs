using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableInterfaces.Models;

namespace TimeTableASP.Pages
{
    public class EventsModel : PageModel
    {

        private readonly TimetableInterfaces.Interfaces.ICalendarService _ics;

        public EventsModel(TimetableInterfaces.Interfaces.ICalendarService ics)
        {
            _ics = ics;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event =  _ics.ListEvents("Adrian");
        }
    }
}
