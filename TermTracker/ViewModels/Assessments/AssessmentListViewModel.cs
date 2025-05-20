using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;
using TermTracker.Views;


namespace TermTracker.ViewModels.Assessments
{
    public class AssessmentListViewModel : BaseViewModel
    {
        private Course _course;

        public ObservableCollection<Assessment> Assessments { get; set; } = new();

        public ICommand AddAssessmentCommand { get; }

        public AssessmentListViewModel(Course course)
        {
            _course = course;
            LoadAssessments();

            AddAssessmentCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(AddAssessmentPage), true, new Dictionary<string, object>
                {
                    { "SelectedCourse", _course }
                });
            });
        }

        public async void LoadAssessments()
        {
            var db = await DatabaseService.GetConnection();
            var list = await db.Table<Assessment>().Where(a => a.CourseId == _course.Id).ToListAsync();

            Assessments.Clear();
            foreach (var a in list)
                Assessments.Add(a);
        }

        public ICommand DeleteAssessmentCommand => new Command<Assessment>(async (assessment) =>
        {
            bool confirm = await Shell.Current.DisplayAlert("Delete", $"Delete '{assessment.Title}'?", "Yes", "No");
            if (!confirm) return;

            var db = await DatabaseService.GetConnection();
            await db.DeleteAsync(assessment);
            Assessments.Remove(assessment);
        });
       

    }
}
