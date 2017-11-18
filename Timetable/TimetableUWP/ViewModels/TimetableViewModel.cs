using System;

using TimetableUWP.Helpers;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using TimetableMockService.MockServices;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using TimetableUWP.Command;
using TimetableInterfaces.Interfaces;
using Windows.UI.Xaml.Controls;
using TimetableUWP.Views;
using Windows.UI.Popups;

namespace TimetableUWP.ViewModels
{
    public class TimetableViewModel : Observable
    {
        public ICalendarService Cs { get; }

        public String Username { get; set; }

        public ObservableCollection<Event> TimetableEvents { get; set; }

        public ObservableCollection<Event> Monday { get; set; }
        public ObservableCollection<Event> Tuesday { get; set; }
        public ObservableCollection<Event> Wednesday { get; set; }
        public ObservableCollection<Event> Thursday { get; set; }
        public ObservableCollection<Event> Friday { get; set; }
        public ObservableCollection<Event> Saturday { get; set; }
        public ObservableCollection<Event> Sunday { get; set; }


        public TimetableModelViewCommand AddCommand { get; }
        public TimetableModelViewCommand DeleteCommand { get; }
        public TimetableModelViewCommand LoginCommand { get; }

        private int temporaryIdCounter = 3;

        public TimetableViewModel()
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            Cs = mcsf.CreateCalendarService("MCS");
            
            TimetableEvents = new ObservableCollection<Event>();

            Monday = new ObservableCollection<Event>();
            Tuesday = new ObservableCollection<Event>();
            Wednesday = new ObservableCollection<Event>();
            Thursday = new ObservableCollection<Event>();
            Friday = new ObservableCollection<Event>();
            Saturday = new ObservableCollection<Event>();
            Sunday = new ObservableCollection<Event>();

            AddCommand = new TimetableModelViewCommand(this.AddEvent, this.IsNoMoreThanTwenty);
            DeleteCommand = new TimetableModelViewCommand(this.DeleteEvent, this.IsTimetableEmpty);
            LoginCommand = new TimetableModelViewCommand(this.Login, () => true);
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

        public void Login()
        {
            TimetableEvents.Clear();
            ClearEventArrays();

            if (Username == null)
            {
                Alert("No username given");
            }
            else if (Username == "Gergely")
            {
                //login not properly implemented yet (logins automatically)
                Cs.UserLogin(Username, "pw123");

                ObservableCollection<Event> temp = new ObservableCollection<Event>(Cs.ListEvents(Username));
                foreach(Event e in temp)
                {
                    TimetableEvents.Add(e);
                }
                SortEventsIntoDays();
            }
            else if (Username == "Adrian")
            {
                //logins automatically
                Cs.UserLogin(Username, "pw789");

                ObservableCollection<Event> temp = new ObservableCollection<Event>(Cs.ListEvents(Username));
                foreach (Event e in temp)
                {
                    TimetableEvents.Add(e);
                }
                SortEventsIntoDays();
            }
            else
            {
                Alert("Wrong username!");
            }
        }

        private void ClearEventArrays()
        {
            Monday.Clear();
            Tuesday.Clear();
            Wednesday.Clear();
            Thursday.Clear();
            Friday.Clear();
            Saturday.Clear();
            Sunday.Clear();
        }

        public void SortEventsIntoDays()
        {
            ClearEventArrays();

            foreach(Event e in TimetableEvents)
            {
                switch(e.getValidEventDate().Day)
                {
                    case 1:
                        Monday.Add(e);
                        break;
                    case 2:
                        Tuesday.Add(e);
                        break;
                    case 3:
                        Wednesday.Add(e);
                        break;
                    case 4:
                        Thursday.Add(e);
                        break;
                    case 5:
                        Friday.Add(e);
                        break;
                    case 6:
                        Saturday.Add(e);
                        break;
                    case 7:
                        Sunday.Add(e);
                        break;
                }
            }
        }

        public void AddEvent()
        {
            DisplayNewEventDialog();
        }

        private async void DisplayNewEventDialog()
        {
            var dialog = new CreateNewEventDialog(this, Username, temporaryIdCounter++);
            await dialog.ShowAsync();
        }

        public void DeleteEvent()
        {
            Cs.DeleteEvent(temporaryIdCounter-1);
            temporaryIdCounter--;
            TimetableEvents.RemoveAt(TimetableEvents.Count - 1);
        }

        public async void Alert(String message)
        {
            MessageDialog md = new MessageDialog(message);
            await md.ShowAsync();
        }
    }
}
