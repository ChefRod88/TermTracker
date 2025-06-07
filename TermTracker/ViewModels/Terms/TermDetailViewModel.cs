using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TermTracker.Models.TermTrackerCore;
using TermTracker.Services;
using TermTracker.Views;


namespace TermTracker.ViewModels.Terms
{
    /// <summary>
    /// View model for displaying a single term and its courses.
    /// </summary>
    public class TermDetailViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string TermTitle { get; set; }
        public ObservableCollection<Course> Courses { get; set; } = new();

        private Course _selectedCourse;
        private Term _term;

        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged();
            }
        }

        

        /// <summary>
        /// Creates the view model for the given term and loads courses.
        /// </summary>
        /// <param name="term">The term to display.</param>
        public TermDetailViewModel(Term term)
        {
            _term = term;
            TermTitle = term.Title;
            LoadCourses();
        }

        /// <summary>
        /// Loads all courses for the term from the database.
        /// </summary>
        public async void LoadCourses()
        {
            var db = await DatabaseService.GetConnection();
            var courseList = await db.Table<Course>()
                                     .Where(c => c.TermId == _term.Id)
                                     .ToListAsync();

            Courses.Clear();
            foreach (var course in courseList)
                Courses.Add(course);
        }

        /// <summary>
        /// Navigates to the add course page for this term.
        /// </summary>
        public ICommand AddCourseCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(AddCoursePage), true, new Dictionary<string, object>
            {
                { "SelectedTerm", _term }
            });
        });

        /// <summary>
        /// Opens the edit screen for the currently selected course.
        /// </summary>
        public ICommand UpdateSelectedCourseCommand => new Command(async () =>
        {
            if (SelectedCourse == null)
            {
                await Shell.Current.DisplayAlert("Error", "You must select a course to update.", "OK");
                return;
            }

            await Shell.Current.GoToAsync(nameof(EditCoursePage), true, new Dictionary<string, object>
            {
                { "SelectedCourse", SelectedCourse }
            });
        });

        /// <summary>
        /// Deletes the currently selected course after user confirmation.
        /// </summary>
        public ICommand DeleteSelectedCourseCommand => new Command(async () =>
        {
            if (SelectedCourse == null)
            {
                await Shell.Current.DisplayAlert("Error", "You must select a course to delete.", "OK");
                return;
            }

            var confirm = await Shell.Current.DisplayAlert("Confirm", $"Delete {SelectedCourse.Title}?", "Yes", "No");
            if (!confirm) return;

            var db = await DatabaseService.GetConnection();
            await db.DeleteAsync(SelectedCourse);

            Courses.Remove(SelectedCourse);
            SelectedCourse = null;
        });

        /// <summary>
        /// Sets the selected course from the UI list.
        /// </summary>
        public ICommand SelectCourseCommand => new Command<Course>(course =>
        {
            SelectedCourse = course;
        });

        /// <summary>
        /// Opens the assessment list for a given course.
        /// </summary>
        public ICommand ManageAssessmentsCommand => new Command<Course>(async (selectedCourse) =>
        {
            if (selectedCourse != null)
            {
                await Shell.Current.GoToAsync(nameof(AssessmentListPage), true,
                    new Dictionary<string, object> { { "SelectedCourse", selectedCourse } });
            }
        });



    }
}

