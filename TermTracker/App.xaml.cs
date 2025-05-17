using TermTracker.Services;
using TermTracker.Views;

namespace TermTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Seed fake data
            Task.Run(async () => await DatabaseService.SeedSampleData());

            // Optional: force start on LandingPage
            Routing.RegisterRoute(nameof(LandingPage), typeof(LandingPage));
            Shell.Current.GoToAsync($"//{nameof(LandingPage)}");
        }
    }


    }

