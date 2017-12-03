using System;
using TimetableInterfaces.Models;
using TimetableUWP.ViewModels;
using Windows.UI.Xaml.Controls;

namespace TimetableUWP.Views
{
    public sealed partial class DeleteEventDialog : ContentDialog
    {
        private TimetableViewModel tvm;
        private string username;

        public DeleteEventDialog()
        {
            this.InitializeComponent();
        }

        public DeleteEventDialog(TimetableViewModel tvm, string username)
        {
            this.tvm = tvm;
            this.username = username;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            IsPrimaryButtonEnabled = false;

            int id = Int32.Parse(tbEventId.Text);

            try
            {
                Event evt = tvm.Cs.GetEvent(id);

                tvm.Cs.DeleteEvent(id);
                tvm.TimetableEvents.Remove(evt);

                tvm.SortEvents();
                tvm.DeleteCommand.Update();
                tvm.AddCommand.Update();
            }
            catch(Exception e)
            {
                tvm.Alert(e.Message);
            }
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void TbEventId_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            sender.Text = sender.Text.Trim();

            if (!Int32.TryParse(sender.Text, out int temp) && sender.Text != "")
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = sender.Text.Remove(pos, 1);
                sender.SelectionStart = pos;
            }
        }
    }
}
