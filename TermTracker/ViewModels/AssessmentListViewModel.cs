using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models;
using TermTracker.Services;
using TermTracker.Views;

namespace TermTracker.ViewModels
{
    public class AssessmentListViewModel
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
    }
}
