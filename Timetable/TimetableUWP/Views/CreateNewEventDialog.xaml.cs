using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TimetableInterfaces.Models;
using TimetableUWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace TimetableUWP.Views
{
    public sealed partial class CreateNewEventDialog : ContentDialog
    {
        private int eventID;
        private TimetableViewModel tvm;
        private string username;

        public CreateNewEventDialog()
        {
            this.InitializeComponent();
        }

        public CreateNewEventDialog(TimetableViewModel tvm, String username, int id)
        {
            eventID = id;
            this.tvm = tvm;
            this.username = username;
            this.InitializeComponent();
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            try
            {
                Category category = new Category(1, tbCategory.Text, 1);

                int parity;
                if ((bool)rb0.IsChecked)
                {
                    parity = 0;
                }
                else if ((bool)rb1.IsChecked)
                {
                    parity = 1;
                }
                else
                {
                    parity = 2;
                }

                EventDate ed = new EventDate(eventID,
                    tpStartTime.Time, tpEndTime.Time, cbDays.SelectedIndex + 1, parity, true);
                List<EventDate> dates = new List<EventDate>
            {
                ed
            };
                Event e = new Event(
                     eventID, tvm.Cs.GetUser(username), tbName.Text, tbDescription.Text, tbLocation.Text,
                     cbPriority.SelectedIndex + 1, category, dates
                     );

                tvm.Cs.AddEvent(e);
                tvm.TimetableEvents.Add(e);
            }
            catch (Exception e)
            {
                tvm.Alert(e.Message);
            }
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
    }
}
