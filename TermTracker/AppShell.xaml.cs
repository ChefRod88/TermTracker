using TermTracker.Views;

namespace TermTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // 🌟 Initial landing splash screen
            Routing.RegisterRoute(nameof(LandingPage), typeof(LandingPage));

            // 📅 Term-related pages
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(AddTermPage), typeof(AddTermPage));
            Routing.RegisterRoute(nameof(TermDetailPage), typeof(TermDetailPage));

            // 📘 Course-related pages
            Routing.RegisterRoute(nameof(AddCoursePage), typeof(AddCoursePage));
            Routing.RegisterRoute(nameof(EditCoursePage), typeof(EditCoursePage));

            // ✅ Assessment-related pages
            Routing.RegisterRoute(nameof(AssessmentListPage), typeof(AssessmentListPage));
            Routing.RegisterRoute(nameof(AddAssessmentPage), typeof(AddAssessmentPage));
            Routing.RegisterRoute(nameof(EditAssessmentPage), typeof(EditAssessmentPage));

            Items.Add(new ShellContent
            {
                Title = "Splash",
                ContentTemplate = new DataTemplate(typeof(LandingPage)),
                Route = nameof(LandingPage)
            });

        }
    }
}
