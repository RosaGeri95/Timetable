using System;

using TimetableUWP.Helpers;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using TimetableUWP.Command;

namespace TimetableUWP.ViewModels
{
    public class TimetableViewModel : Observable
    {
        private MockCalendarService mcs;

        public ObservableCollection<Event> TimetableEvents { get; set; }

        public TimetableModelViewCommand AddCommand { get; }
        public TimetableModelViewCommand DeleteCommand { get; }

        private int temporaryIdCounter = 3;

        public TimetableViewModel()
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            mcs = (MockCalendarService)mcsf.CreateCalendarService("MCS");

            TimetableEvents = new ObservableCollection<Event>(mcs.ListEvents(mcs.CurrentUser.Username));

            AddCommand = new TimetableModelViewCommand(this.AddEvent, this.IsNoMoreThanTwenty);
            DeleteCommand = new TimetableModelViewCommand(this.DeleteEvent, this.IsTimetableEmpty);

        }
        private bool IsNoMoreThanTwenty()
        {
            if(TimetableEvents.Count >= 20)
            {
                return false;
            }
            return true;
        }

        private bool IsTimetableEmpty()
        {
            if(TimetableEvents.Count == 0)
            {
                return false;
            }
            return true;
        }

        
        public void AddEvent()
        {
            Category category3 = new Category(2, "Exam", 2);

            EventDate ed0 = new EventDate(0,
                new TimeSpan(14, 0, 0), new TimeSpan(14, 20, 0), 1, 2);
            List<EventDate> dates0 = new List<EventDate>
            {
                ed0
            };
            Event e = new Event(
                 temporaryIdCounter, mcs.CurrentUser, "Temalabor", "AUT tanszék témalabora", "QB202",
                 1, category3, dates0
                 );

            mcs.AddEvent(e);
            TimetableEvents.Add(e);

            temporaryIdCounter++;
        }

        public void DeleteEvent()
        {
            mcs.DeleteEvent(temporaryIdCounter-1);
            temporaryIdCounter--;

            TimetableEvents.RemoveAt(TimetableEvents.Count - 1);
        }

    }
}
