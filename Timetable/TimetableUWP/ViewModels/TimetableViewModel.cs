using System;

using TimetableUWP.Helpers;
using TimetableInterfaces.Models;
using TimetableMockService.Factory;
using System.Collections.ObjectModel;
using TimetableUWP.Command;
using TimetableInterfaces.Interfaces;
using TimetableUWP.Views;
using Windows.UI.Popups;

namespace TimetableUWP.ViewModels
{
    public class TimetableViewModel : Observable
    {
        public ICalendarService Cs { get; }

        public string Username { get; set; }

        public ObservableCollection<Event> TimetableEvents { get; set; }

        public ObservableCollection<Event> Monday { get; set; }
        public ObservableCollection<Event> Tuesday { get; set; }
        public ObservableCollection<Event> Wednesday { get; set; }
        public ObservableCollection<Event> Thursday { get; set; }
        public ObservableCollection<Event> Friday { get; set; }
        public ObservableCollection<Event> Saturday { get; set; }
        public ObservableCollection<Event> Sunday { get; set; }

        public TimetableCommand AddCommand { get; }
        public TimetableCommand DeleteCommand { get; }
        public TimetableCommand LoginCommand { get; }

        private int idCounter = 1000;
        private bool isLoggedIn = false;

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

            AddCommand = new TimetableCommand(this.AddEvent, this.CanAddEvent);
            DeleteCommand = new TimetableCommand(this.DeleteEvent, this.IsTimetableEmpty);
            LoginCommand = new TimetableCommand(this.Login, () => true);
        }
        private bool CanAddEvent()
        {
            if(TimetableEvents.Count >= 20 || !isLoggedIn)
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

            if (Username == "Gergely")
            {
                //logins automatically
                Cs.UserLogin(Username, "pw123");
                isLoggedIn = true;

                ObservableCollection<Event> temp = new ObservableCollection<Event>(Cs.ListEvents(Username));
                foreach(Event e in temp)
                {
                    TimetableEvents.Add(e);
                }
                SortEvents();
            }
            else if (Username == "Adrian")
            {
                //logins automatically
                Cs.UserLogin(Username, "pw789");
                isLoggedIn = true;

                ObservableCollection<Event> temp = new ObservableCollection<Event>(Cs.ListEvents(Username));
                foreach (Event e in temp)
                {
                    TimetableEvents.Add(e);
                }
                SortEvents();
            }
            else
            {
                Alert("Invalid username!");
                isLoggedIn = false;
            }

            DeleteCommand.Update();
            AddCommand.Update();
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

        public void SortEvents()
        {
            ClearEventArrays();

            foreach(Event e in TimetableEvents)
            {
                switch(e.Day)
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
            var dialog = new CreateNewEventDialog(this, Username, idCounter++);
            await dialog.ShowAsync();
        }

        public void DeleteEvent()
        {
            DisplayDeleteEventDialog();
        }

        private async void DisplayDeleteEventDialog()
        {
            var dialog = new DeleteEventDialog(this, Username);
            await dialog.ShowAsync();
        }

        public async void Alert(String message)
        {
            MessageDialog md = new MessageDialog(message);
            await md.ShowAsync();
        }
    }
}
