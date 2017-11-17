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

        public TimetableModelViewCommand AddCommand { get; }
        public TimetableModelViewCommand DeleteCommand { get; }
        public TimetableModelViewCommand LoginCommand { get; }

        private int temporaryIdCounter = 3;

        public TimetableViewModel()
        {
            MyCalendarServiceFactory mcsf = new MyCalendarServiceFactory();
            Cs = mcsf.CreateCalendarService("MCS");
            
            TimetableEvents = new ObservableCollection<Event>();

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
            if (TimetableEvents.Count > 0)
                TimetableEvents.Clear();

            
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
            }
            else
            {
                Alert("Wrong username!");
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
