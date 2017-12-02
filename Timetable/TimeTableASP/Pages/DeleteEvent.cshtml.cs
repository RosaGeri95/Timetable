using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;
using Microsoft.Extensions.Logging;

namespace TimeTableASP.Pages
{
    public class DeleteEventModel : PageModel
    {
        private readonly ICalendarService  _ics;
 

        public DeleteEventModel(ICalendarService ics)
        {
            _ics = ics;
        }

        public Event Event { get; set; }

        public void OnGet(int id)
        {

            Event = _ics.GetEvent(id);

            if (Event == null)
            {
                throw new Exception();
            }
            
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            if (_ics.DeleteEvent(id) == false)
                return NotFound();

            return RedirectToPage("./Events");

        }
    }
}