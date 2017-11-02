using System;

using TimetableUWP.Helpers;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TimetableUWP.ViewModels
{
    public class TimetableViewModel : Observable
    {
        public ObservableCollection<Event> TimetableEvents { get; set; }
        private MockCalendarService mcs;

        public TimetableViewModel()
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            mcs = (MockCalendarService)mcsf.CreateCalendarService("MCS");

            TimetableEvents = new ObservableCollection<Event>(mcs.ListEvents(mcs.CurrentUser.Username));

        }


        /* ---------------  KIZÁRÓLAG TESZT CÉLJÁBÓL -------------- */

        public void Add()
        {
            Category category3 = new Category(2, "Exam", 2);

            EventDate ed0 = new EventDate(0,
                new TimeSpan(14, 0, 0), new TimeSpan(14, 20, 0), 1, 2);
            List<EventDate> dates0 = new List<EventDate>
            {
                ed0
            };
            TimetableEvents.Add(new Event(
                 0, mcs.CurrentUser, "Temalabor", "AUT tanszék témalabora", "QB202",
                 1, category3, dates0
                 ));

        }
    }
}
