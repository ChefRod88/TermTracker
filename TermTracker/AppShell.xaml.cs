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
            Routing.RegisterRoute(nameof(EditCoursePage), typeof(EditCoursePage));
            Routing.RegisterRoute(nameof(AssessmentListPage), typeof(AssessmentListPage));
            Routing.RegisterRoute(nameof(AddAssessmentPage), typeof(AddAssessmentPage));
            Routing.RegisterRoute(nameof(AddAssessmentPage), typeof(AddAssessmentPage));
            Routing.RegisterRoute(nameof(EditAssessmentPage), typeof(EditAssessmentPage));







        }
    }
}
