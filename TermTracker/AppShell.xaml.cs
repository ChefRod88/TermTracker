using TermTracker.Views;

namespace TermTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TermDetailPage), typeof(TermDetailPage));
            Routing.RegisterRoute(nameof(AddCoursePage), typeof(AddCoursePage));


        }
    }
}
