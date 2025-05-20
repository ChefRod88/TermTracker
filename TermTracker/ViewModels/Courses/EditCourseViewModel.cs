using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;


namespace TermTracker.ViewModels.Courses
{
    public class EditCourseViewModel : BaseViewModel
    {
        private Course _course;

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }

        public ObservableCollection<string> StatusOptions { get; } = new()
        {
            "Not Started", "In Progress", "Dropped", "Completed"
        };

        public string SelectedStatus { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public EditCourseViewModel(Course course)
        {
            _course = course;

            Title = course.Title;
            StartDate = course.StartDate;
            EndDate = course.EndDate;
            SelectedStatus = course.Status;
            Notes = course.Notes;

            SaveCommand = new Command(async () =>
            {
                _course.Title = Title;
                _course.StartDate = StartDate;
                _course.EndDate = EndDate;
                _course.Status = SelectedStatus;
                _course.Notes = Notes;

                var db = await DatabaseService.GetConnection();
                await db.UpdateAsync(_course);

                await Shell.Current.GoToAsync("..");
            });

            DeleteCommand = new Command(async () =>
            {
                var confirm = await Shell.Current.DisplayAlert("Confirm Delete", "Are you sure you want to delete this course?", "Yes", "No");
                if (!confirm) return;

                var db = await DatabaseService.GetConnection();
                await db.DeleteAsync(_course);

                await Shell.Current.GoToAsync("..");
            });
        }
    }
}

