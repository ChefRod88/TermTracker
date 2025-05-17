using System.Collections.ObjectModel;
using System.Windows.Input;
using TermTracker.Models;
using TermTracker.Services;
using TermTracker.Views;

namespace TermTracker.ViewModels
{
    public class TermDetailViewModel
    {
        public string TermTitle { get; set; }
        public ObservableCollection<Course> Courses { get; set; } = new();

        private Term _term;

        public TermDetailViewModel(Term term)
        {
            _term = term;
            TermTitle = term.Title;
            LoadCourses();
        }

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

        public ICommand AddCourseCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(AddCoursePage), true, new Dictionary<string, object>
    {
        { "SelectedTerm", _term }
    });
        });

    }
}

