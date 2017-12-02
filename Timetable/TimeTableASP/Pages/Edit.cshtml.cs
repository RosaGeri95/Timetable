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
    public class EditModel : PageModel
    {
        private readonly ICalendarService _ics;

        [BindProperty]
        public Event Event { get; set; }

        public EditModel(ICalendarService ics)
        {
            _ics = ics;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Event = _ics.GetEvent(id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public TimeSpan StartDate { get; set; }
        [BindProperty]
        public TimeSpan EndDate { get; set; }
        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            Event.Category = Category;
            Event.StartDate = StartDate;
            Event.EndDate = EndDate;

            if (_ics.ModifyEvent(Event) == false)
                return NotFound();

            return RedirectToPage("./Events");
        }
    }
}