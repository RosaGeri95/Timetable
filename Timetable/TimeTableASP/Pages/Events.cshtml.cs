using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeTableASP.Pages
{
    public class EventsModel : PageModel
    {
        public string Message { get; set; }
        public int Mynumber { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
            Mynumber = 16;
        }
    }
}
