using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;
using TermTracker.Views;


namespace TermTracker.ViewModels.Courses
{
    /// <summary>
    /// View model used by <see cref="AddCoursePage"/> for creating a new
    /// course within a term.
    /// </summary>
    public class AddCourseViewModel : BaseViewModel
    {
        private Term _term;

        public string Title { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);
        public string Notes { get; set; }

        public ObservableCollection<string> StatusOptions { get; } = new()
        {
            "Not Started", "In Progress", "Dropped", "Completed"
        };

        public string SelectedStatus { get; set; }

        public ICommand SaveCommand { get; }

        /// <summary>
        /// Creates a new instance for the specified term.
        /// </summary>
        /// <param name="term">Parent term to associate with the course.</param>
        public AddCourseViewModel(Term term)
        {
            _term = term;

            // command executed when the user taps "Save" on the Add Course page
            SaveCommand = new Command(async () =>
            {
                // basic validation
                if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(SelectedStatus))
                {
                    await Shell.Current.DisplayAlert("Error", "Please enter course title and status.", "OK");
                    return;
                }

                var newCourse = new Course
                {
                    Title = Title,
                    TermId = _term.Id,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Status = SelectedStatus,
                    Notes = Notes
                };

                var db = await DatabaseService.GetConnection();
                await db.InsertAsync(newCourse);

                // return to the previous page (Term detail)
                await Shell.Current.GoToAsync("..");
            });
        }
     

    }
}
