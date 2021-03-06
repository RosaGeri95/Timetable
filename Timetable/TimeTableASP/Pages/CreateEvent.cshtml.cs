using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;


namespace TimeTableASP.Pages
{
    public class CreateEventModel : PageModel
    {
        private readonly ICalendarService _ics;

        public CreateEventModel(ICalendarService ics)
        {
            _ics = ics;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            Event.EventOwner = _ics.GetUser("Adrian");

            _ics.AddEvent(Event);

            return RedirectToPage("./Events");
        }
    }
}
