using System;

using TimetableUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TimetableUWP.Views
{
    public sealed partial class TimetablePage : Page
    {
        public TimetableViewModel ViewModel { get; } = new TimetableViewModel();

        public TimetablePage()
        {
            InitializeComponent();
        }
    }
}
