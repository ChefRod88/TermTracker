using TermTracker.Views;

namespace TermTracker.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LogoStack.FadeTo(1, 1000);
            await Task.Delay(2000);
            await Shell.Current.GoToAsync(nameof(DashboardPage));


        }
    }
}
