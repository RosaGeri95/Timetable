using System;

using TimetableUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TimetableUWP.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
