using System;

using TimetableUWP.Helpers;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;
using System.Collections.ObjectModel;

namespace TimetableUWP.ViewModels
{
    public class TimetableViewModel : Observable
    {
        public ObservableCollection<Event> TimetableEvents { get; set; }

        public TimetableViewModel()
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            MockCalendarService mcs = (MockCalendarService)mcsf.CreateCalendarService("MCS");

            TimetableEvents = new ObservableCollection<Event>(mcs.ListEvents(mcs.CurrentUser.Username));

        }
        
    }
}
