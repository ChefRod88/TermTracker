using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models;
using TermTracker.Services;

namespace TermTracker.ViewModels
{
    public class AddCourseViewModel
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

        public AddCourseViewModel(Term term)
        {
            _term = term;

            SaveCommand = new Command(async () =>
            {
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

                await Shell.Current.GoToAsync(".."); // Navigate back
            });
        }
    }
}
