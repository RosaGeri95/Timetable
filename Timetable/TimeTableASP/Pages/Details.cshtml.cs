using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableInterfaces.Models;
using TimetableInterfaces.Interfaces;

namespace TimeTableASP.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICalendarService _ics;

        public DetailsModel(ICalendarService ics)
        {
            _ics = ics;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {


            Event = _ics.GetEvent(id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}