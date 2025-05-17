using TermTracker.Services;

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
        }


    }
}
