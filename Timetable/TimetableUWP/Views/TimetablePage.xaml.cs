using System;

using TimetableUWP.ViewModels;

using Windows.UI.Xaml.Controls;
using TimetableInterfaces.Models;
using TimetableMockService.MockServices;
using System.Collections.Generic;

namespace TimetableUWP.Views
{
    public sealed partial class TimetablePage : Page
    {
        public TimetableViewModel ViewModel { get; } = new TimetableViewModel();

        public TimetablePage()
        {
            InitializeComponent();
        }

        private void btnCreateEvent_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Add();




        }
    }
}
